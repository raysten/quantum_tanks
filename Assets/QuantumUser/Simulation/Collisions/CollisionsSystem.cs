using UnityEngine.Scripting;

namespace Quantum
{
    [Preserve]
    public unsafe class CollisionsSystem : SystemSignalsOnly, ISignalOnTriggerEnter3D
    {
        public void OnTriggerEnter3D(Frame frame, TriggerInfo3D info)
        {
            if (frame.Unsafe.TryGetPointer<Bullet>(info.Entity, out var bullet))
            {
                if (frame.Unsafe.TryGetPointer<TankRotator>(info.Other, out var tankRotator))
                {
                    frame.Signals.OnCollisionBulletHitTank(info, bullet, tankRotator);
                }
            }
        }
    }
}
