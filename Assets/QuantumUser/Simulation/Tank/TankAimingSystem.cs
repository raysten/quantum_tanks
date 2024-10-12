using Photon.Deterministic;
using UnityEngine.Scripting;

namespace Quantum
{
    [Preserve]
    public unsafe class TankAimingSystem : SystemMainThreadFilter<GunFilter>
    {
        private static readonly FP _rotationSpeed = FP._2;
        private static readonly int _maxRotation = 60;

        public override void Update(Frame frame, ref GunFilter filter)
        {
            Input* input = default;

            if (frame.Unsafe.TryGetPointer(filter.Entity, out PlayerLink* playerLink))
            {
                input = frame.GetPlayerInput(playerLink->PlayerRef);
            }

            UpdateRotation(frame, filter, input);
        }

        private void UpdateRotation(Frame frame, GunFilter filter, Input* input)
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

        private void Rotate(GunFilter filter, int direction)
        {
            var rotationAroundZ = filter.Transform->EulerAngles.Z;
            var newRotationAroundZ = FPMath.Clamp(rotationAroundZ + _rotationSpeed * direction, -_maxRotation, _maxRotation);
            filter.Transform->Rotation = FPQuaternion.Euler(0, 0, newRotationAroundZ);
        }
    }
}
