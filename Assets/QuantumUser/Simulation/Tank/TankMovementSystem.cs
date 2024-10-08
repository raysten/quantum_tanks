using Photon.Deterministic;
using UnityEngine.Scripting;

namespace Quantum
{
    [Preserve]
    public unsafe class TankMovementSystem : SystemMainThreadFilter<TankMovementSystem.Filter>
    {
        public struct Filter
        {
            public EntityRef Entity;
            public Transform3D* Transform;
        }

        private FP _moveSpeed = FP._0_02;

        public override void Update(Frame frame, ref Filter filter)
        {
            Input* input = default;

            if (frame.Unsafe.TryGetPointer(filter.Entity, out PlayerLink* playerLink))
            {
                input = frame.GetPlayerInput(playerLink->PlayerRef);
            }

            UpdateMovement(frame, filter, input);
        }

        private void UpdateMovement(Frame frame, Filter filter, Input* input)
        {
            if (input->Right)
            {
                filter.Transform->Position += FPVector3.Right * _moveSpeed;
            }

            if (input->Left)
            {
                filter.Transform->Position += FPVector3.Left * _moveSpeed;
            }
        }
    }
}
