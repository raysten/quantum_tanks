using Photon.Deterministic;

namespace Quantum
{
    public class TankConfig : AssetObject
    {
        public FP moveSpeed = FP._0_02;
        public FP fireInterval = FP._0_10;
        public AssetRef<EntityPrototype> bulletPrototype;
    }
}
