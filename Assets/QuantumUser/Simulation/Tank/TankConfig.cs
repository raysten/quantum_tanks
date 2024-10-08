using Photon.Deterministic;

namespace Quantum
{
    public class TankConfig : AssetObject
    {
        public FP MoveSpeed = FP._0_02;
        public FP FireInterval = FP._0_10;
        public FP ShootingOffset = FP._0_50;
        public AssetRef<EntityPrototype> BulletPrototype;
    }
}
