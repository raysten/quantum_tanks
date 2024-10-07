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
            var input = frame.GetPlayerInput(0);

            UpdateRotation(frame, filter, input);
        }

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
    }
}
