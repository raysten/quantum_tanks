using UnityEngine.Scripting;

namespace Quantum
{
    [Preserve]
    public unsafe class TankSpawnSystem : SystemSignalsOnly, ISignalOnPlayerAdded
    {
        public void OnPlayerAdded(Frame frame, PlayerRef player, bool firstTime)
        {
            var playerData = frame.GetPlayerData(player);
            var entityPrototypeAsset = frame.FindAsset(playerData.PlayerAvatar);
            var tankEntity = frame.Create(entityPrototypeAsset);

            var playerLink = new PlayerLink { PlayerRef = player};
            frame.Add(tankEntity, playerLink);
        }
    }
}
