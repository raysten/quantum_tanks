using Photon.Deterministic;
using UnityEngine.Scripting;

namespace Quantum
{
    [Preserve]
    public unsafe class TankShootingSystem : SystemMainThreadFilter<TankShootingSystem.Filter>
    {
        public struct Filter
        {
            public EntityRef Entity;
            public Transform3D* Transform;
            public TankRotator* Rotator;
        }

        private FP _rotationSpeed = FP._2;

        public override void Update(Frame frame, ref Filter filter)
        {
            Input* input = default;

            if (frame.Unsafe.TryGetPointer(filter.Entity, out PlayerLink* playerLink))
            {
                input = frame.GetPlayerInput(playerLink->PlayerRef);
            }

            UpdateRotation(frame, filter, input);
            UpdateShooting(frame, filter, input);
        }

        // @todo: extract rotator to another class
        private void UpdateRotation(Frame frame, Filter filter, Input* input)
        {
            if (input->Up)
            {
                filter.Transform->Rotate(0, 0, _rotationSpeed);
            }
            
            if (input->Down)
            {
                filter.Transform->Rotate(0, 0, _rotationSpeed * -1);
            }
        }

        private void UpdateShooting(Frame frame, Filter filter, Input* input)
        {
            var tankConfig = frame.FindAsset(frame.RuntimeConfig.TankConfig);

            if (input->Fire && filter.Rotator->FireInterval <= 0)
            {
                // @todo: rename rotator to gun?
                filter.Rotator->FireInterval = tankConfig.FireInterval;
                var relativeOffset = FPVector3.Up * tankConfig.ShootingOffset;
                var spawnPosition = filter.Transform->TransformPoint(relativeOffset);
                frame.Signals.Shoot(filter.Entity, spawnPosition, tankConfig.BulletPrototype);
            }
            else
            {
                filter.Rotator->FireInterval -= frame.DeltaTime;
            }
        }
    }
}
