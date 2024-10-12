using Photon.Deterministic;
using UnityEngine.Scripting;

namespace Quantum
{
    [Preserve]
    public unsafe class TankShootingSystem : SystemMainThreadFilter<GunFilter>
    {
        public override void Update(Frame frame, ref GunFilter filter)
        {
            var input = TankUtility.RetrievePlayerInput(frame, filter.Entity);
            UpdateShooting(frame, filter, input);
        }
        
        private void UpdateShooting(Frame frame, GunFilter filter, Input* input)
        {
            var tankConfig = frame.FindAsset(frame.RuntimeConfig.TankConfig);

            if (input->Fire && filter.Gun->FireInterval <= 0)
            {
                filter.Gun->FireInterval = tankConfig.FireInterval;
                var relativeOffset = FPVector3.Up * tankConfig.ShootingOffset;
                var spawnPosition = filter.Transform->TransformPoint(relativeOffset);
                frame.Signals.Shoot(filter.Entity, spawnPosition, tankConfig.BulletPrototype);
            }
            else
            {
                filter.Gun->FireInterval -= frame.DeltaTime;
            }
        }
    }
}
