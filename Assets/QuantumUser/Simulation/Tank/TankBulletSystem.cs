using Photon.Deterministic;
using UnityEngine.Scripting;

namespace Quantum
{
    [Preserve]
    public unsafe class TankBulletSystem : SystemSignalsOnly, ISignalTankShoot
    {
        public void TankShoot(Frame frame, EntityRef owner, FPVector3 spawnPosition, AssetRef<EntityPrototype> bulletPrototype)
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
    }
}
