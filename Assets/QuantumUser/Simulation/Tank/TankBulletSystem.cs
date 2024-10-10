using Photon.Deterministic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Quantum
{
    [Preserve]
    public unsafe class TankBulletSystem : SystemMainThreadFilter<TankBulletSystem.Filter>, ISignalShoot, ISignalOnCollisionBulletHitTank
    {
        public struct Filter
        {
            public EntityRef Entity;
            public Bullet* Bullet;
        }

        public override void Update(Frame frame, ref Filter filter)
        {
            UpdateTimeToLive(frame, filter);
        }

        private static void UpdateTimeToLive(Frame frame, Filter filter)
        {
            filter.Bullet->TimeToLive -= frame.DeltaTime;

            if (filter.Bullet->TimeToLive <= 0)
            {
                frame.Destroy(filter.Entity);
            }
        }

        public void Shoot(Frame frame, EntityRef owner, FPVector3 spawnPosition, AssetRef<EntityPrototype> bulletPrototype)
        {
            var bulletEntity = frame.Create(bulletPrototype);
            var bulletTransform = frame.Unsafe.GetPointer<Transform3D>(bulletEntity);
            var ownerTransform = frame.Unsafe.GetPointer<Transform3D>(owner);
            
            bulletTransform->Position = spawnPosition;

            var bullet = frame.Unsafe.GetPointer<Bullet>(bulletEntity);
            var config = frame.FindAsset(bullet->Config);
            bullet->TimeToLive = config.TimeToLive;
            bullet->Owner = owner;

            var body = frame.Unsafe.GetPointer<PhysicsBody3D>(bulletEntity);
            body->AddForce(ownerTransform->Up * config.Force);
        }

        // @todo: move to another system
        public void OnCollisionBulletHitTank(Frame frame, TriggerInfo3D collisionInfo, Bullet* bullet, Tank* tank)
        {
            if (bullet->Owner == tank->TankRotator)
            {
                collisionInfo.IgnoreTrigger = true;
            }
            else
            {
                var tankRotator = frame.Unsafe.GetPointer<TankRotator>(bullet->Owner);
                tankRotator->Score++;
            }
        }
    }
}
