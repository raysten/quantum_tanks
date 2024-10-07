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

        public override void Update(Frame frame, ref Filter filter)
        {
            // filter.Body->AddForce(filter.Transform->Up);
        }
    }
}
