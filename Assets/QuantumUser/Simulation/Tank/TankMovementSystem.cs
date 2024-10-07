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
            public PhysicsBody3D* Body;
        }

        private FP _moveSpeed = FP._0_02;

        public override void Update(Frame frame, ref Filter filter)
        {
            var input = frame.GetPlayerInput(0);
            
            UpdateMovement(frame, filter, input);
        }

        private void UpdateMovement(Frame frame, Filter filter, Input* input)
        {
            if (input->Right)
            {
                filter.Transform->Position += filter.Transform->Right * _moveSpeed;
            }
            
            if (input->Left)
            {
                filter.Transform->Position += filter.Transform->Left * _moveSpeed;
            }
        }
    }
}
