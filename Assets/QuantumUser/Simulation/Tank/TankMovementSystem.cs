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
            public TankMovement* MovementTag;
        }

        public override void Update(Frame frame, ref Filter filter)
        {
            var input = TankUtility.RetrievePlayerInput(frame, filter.Entity);
            UpdateMovement(frame, filter, input);
        }

        private void UpdateMovement(Frame frame, Filter filter, Input* input)
        {
            var config = frame.FindAsset(frame.RuntimeConfig.TankConfig);
            var moveSpeed = config.MoveSpeed;
            
            if (input->Right)
            {
                filter.Transform->Position += FPVector3.Right * moveSpeed;
            }

            if (input->Left)
            {
                filter.Transform->Position += FPVector3.Left * moveSpeed;
            }
        }
    }
}
