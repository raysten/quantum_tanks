﻿using Photon.Deterministic;
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

        // @todo: Assign tankRotator to tank and use just tank?
        public void OnCollisionBulletHitTank(Frame frame, TriggerInfo3D collisionInfo, Bullet* bullet, TankRotator* tankRotator)
        {
            // Debug.LogError($"other: {collisionInfo.Other.ToString()}, entity: {collisionInfo.Entity.ToString()}");
            // Debug.LogError($"bullet owner: {bullet->Owner.ToString()}");

            if (bullet->Owner == collisionInfo.Other)
            {
                collisionInfo.IgnoreTrigger = true;
            }
            else
            {
                frame.Destroy(collisionInfo.Other);
            }
        }
    }
}
