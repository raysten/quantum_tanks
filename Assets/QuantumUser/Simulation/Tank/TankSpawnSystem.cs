using Photon.Deterministic;
using UnityEngine.Scripting;

namespace Quantum
{
    [Preserve]
    public unsafe class TankSpawnSystem : SystemSignalsOnly, ISignalOnPlayerAdded
    {
        private static readonly FP _xPosition = 3;

        public void OnPlayerAdded(Frame frame, PlayerRef player, bool firstTime)
        {
            var playerData = frame.GetPlayerData(player);
            var entityPrototypeAsset = frame.FindAsset(playerData.PlayerAvatar);
            var tankEntity = frame.Create(entityPrototypeAsset);

            var playerLink = new PlayerLink { PlayerRef = player};
            frame.Add(tankEntity, playerLink);
            
            if (frame.Unsafe.TryGetPointer(tankEntity, out Tank* tank))
            {
                var gunPrototypeAsset = tank->GunPrototype;
                var gunEntity = frame.Create(gunPrototypeAsset);
                frame.Add(gunEntity, playerLink);

                tank->TankGun = gunEntity;
            }
            
            AssignInitialPosition(frame, player, tankEntity, tank->TankGun);
        }

        private void AssignInitialPosition(Frame frame, PlayerRef player, EntityRef tankEntity, EntityRef gunEntity)
        {
            var xPosition = CalculateXPosition(player);
            
            if (frame.Unsafe.TryGetPointer<Transform3D>(tankEntity, out var tankTransform))
            {
                tankTransform->Position = new FPVector3(xPosition, 0, 0);
            }
            
            if (frame.Unsafe.TryGetPointer<Transform3D>(gunEntity, out var gunTransform))
            {
                gunTransform->Position = new FPVector3(xPosition, -FP._0_10, 0);
            }
        }

        private FP CalculateXPosition(PlayerRef player)
        {
            FP xPosition;

            if (player == 0)
            {
                xPosition = -_xPosition;
            }
            else
            {
                xPosition = _xPosition;
            }

            return xPosition;
        }
    }
}
