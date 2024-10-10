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

        private static readonly FP _rotationSpeed = FP._2;
        private static readonly int _maxRotation = 60;

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
                Rotate(filter, 1);
            }
            
            if (input->Down)
            {
                Rotate(filter, -1);
            }
        }

        private void Rotate(Filter filter, int direction)
        {
            var rotationAroundZ = filter.Transform->EulerAngles.Z;
            var newRotationAroundZ = FPMath.Clamp(rotationAroundZ + _rotationSpeed * direction, -_maxRotation, _maxRotation);
            filter.Transform->Rotation = FPQuaternion.Euler(0, 0, newRotationAroundZ);
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
