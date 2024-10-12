// <auto-generated>
// This code was auto-generated by a tool, every time
// the tool executes this code will be reset.
//
// If you need to extend the classes generated to add
// fields or methods to them, please create partial
// declarations in another file.
// </auto-generated>
#pragma warning disable 0109
#pragma warning disable 1591


namespace Quantum.Prototypes.Unity {
  using Photon.Deterministic;
  using Quantum;
  using Quantum.Core;
  using Quantum.Collections;
  using Quantum.Inspector;
  using Quantum.Physics2D;
  using Quantum.Physics3D;
  using Byte = System.Byte;
  using SByte = System.SByte;
  using Int16 = System.Int16;
  using UInt16 = System.UInt16;
  using Int32 = System.Int32;
  using UInt32 = System.UInt32;
  using Int64 = System.Int64;
  using UInt64 = System.UInt64;
  using Boolean = System.Boolean;
  using String = System.String;
  using Object = System.Object;
  using FlagsAttribute = System.FlagsAttribute;
  using SerializableAttribute = System.SerializableAttribute;
  using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
  using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
  using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
  using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
  using LayoutKind = System.Runtime.InteropServices.LayoutKind;
  #if QUANTUM_UNITY //;
  using TooltipAttribute = UnityEngine.TooltipAttribute;
  using HeaderAttribute = UnityEngine.HeaderAttribute;
  using SpaceAttribute = UnityEngine.SpaceAttribute;
  using RangeAttribute = UnityEngine.RangeAttribute;
  using HideInInspectorAttribute = UnityEngine.HideInInspector;
  using PreserveAttribute = UnityEngine.Scripting.PreserveAttribute;
  using FormerlySerializedAsAttribute = UnityEngine.Serialization.FormerlySerializedAsAttribute;
  using MovedFromAttribute = UnityEngine.Scripting.APIUpdating.MovedFromAttribute;
  using CreateAssetMenu = UnityEngine.CreateAssetMenuAttribute;
  using RuntimeInitializeOnLoadMethodAttribute = UnityEngine.RuntimeInitializeOnLoadMethodAttribute;
  #endif //;
  
  [System.SerializableAttribute()]
  public unsafe partial class BulletPrototype : Quantum.QuantumUnityPrototypeAdapter<Quantum.Prototypes.BulletPrototype> {
    public FP TimeToLive;
    public Quantum.QuantumEntityPrototype Owner;
    public AssetRef<BulletConfig> Config;
    partial void ConvertUser(Quantum.QuantumEntityPrototypeConverter converter, ref Quantum.Prototypes.BulletPrototype prototype);
    public override Quantum.Prototypes.BulletPrototype Convert(Quantum.QuantumEntityPrototypeConverter converter) {
      var result = new Quantum.Prototypes.BulletPrototype();
      converter.Convert(this.TimeToLive, out result.TimeToLive);
      converter.Convert(this.Owner, out result.Owner);
      converter.Convert(this.Config, out result.Config);
      ConvertUser(converter, ref result);
      return result;
    }
  }
  [System.SerializableAttribute()]
  public unsafe partial class TankPrototype : Quantum.QuantumUnityPrototypeAdapter<Quantum.Prototypes.TankPrototype> {
    public AssetRef<EntityPrototype> GunPrototype;
    public Quantum.QuantumEntityPrototype TankGun;
    partial void ConvertUser(Quantum.QuantumEntityPrototypeConverter converter, ref Quantum.Prototypes.TankPrototype prototype);
    public override Quantum.Prototypes.TankPrototype Convert(Quantum.QuantumEntityPrototypeConverter converter) {
      var result = new Quantum.Prototypes.TankPrototype();
      converter.Convert(this.GunPrototype, out result.GunPrototype);
      converter.Convert(this.TankGun, out result.TankGun);
      ConvertUser(converter, ref result);
      return result;
    }
  }
}
#pragma warning restore 0109
#pragma warning restore 1591
