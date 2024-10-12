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


namespace Quantum.Prototypes {
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
  [Quantum.Prototypes.Prototype(typeof(Quantum.Bullet))]
  public unsafe class BulletPrototype : ComponentPrototype<Quantum.Bullet> {
    public FP TimeToLive;
    public MapEntityId Owner;
    public AssetRef<BulletConfig> Config;
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.Bullet component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.Bullet result, in PrototypeMaterializationContext context = default) {
        result.TimeToLive = this.TimeToLive;
        PrototypeValidator.FindMapEntity(this.Owner, in context, out result.Owner);
        result.Config = this.Config;
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Input))]
  public unsafe partial class InputPrototype : StructPrototype {
    public Button Left;
    public Button Right;
    public Button Up;
    public Button Down;
    public Button Fire;
    partial void MaterializeUser(Frame frame, ref Quantum.Input result, in PrototypeMaterializationContext context);
    public void Materialize(Frame frame, ref Quantum.Input result, in PrototypeMaterializationContext context = default) {
        result.Left = this.Left;
        result.Right = this.Right;
        result.Up = this.Up;
        result.Down = this.Down;
        result.Fire = this.Fire;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.PlayerLink))]
  public unsafe partial class PlayerLinkPrototype : ComponentPrototype<Quantum.PlayerLink> {
    public PlayerRef PlayerRef;
    partial void MaterializeUser(Frame frame, ref Quantum.PlayerLink result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.PlayerLink component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.PlayerLink result, in PrototypeMaterializationContext context = default) {
        result.PlayerRef = this.PlayerRef;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Tank))]
  public unsafe class TankPrototype : ComponentPrototype<Quantum.Tank> {
    public AssetRef<EntityPrototype> GunPrototype;
    public MapEntityId TankGun;
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.Tank component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.Tank result, in PrototypeMaterializationContext context = default) {
        result.GunPrototype = this.GunPrototype;
        PrototypeValidator.FindMapEntity(this.TankGun, in context, out result.TankGun);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.TankGun))]
  public unsafe partial class TankGunPrototype : ComponentPrototype<Quantum.TankGun> {
    public FP FireInterval;
    public Int32 Score;
    partial void MaterializeUser(Frame frame, ref Quantum.TankGun result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.TankGun component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.TankGun result, in PrototypeMaterializationContext context = default) {
        result.FireInterval = this.FireInterval;
        result.Score = this.Score;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.TankMovement))]
  public unsafe partial class TankMovementPrototype : ComponentPrototype<Quantum.TankMovement> {
    [HideInInspector()]
    public Int32 _empty_prototype_dummy_field_;
    partial void MaterializeUser(Frame frame, ref Quantum.TankMovement result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.TankMovement component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.TankMovement result, in PrototypeMaterializationContext context = default) {
        MaterializeUser(frame, ref result, in context);
    }
  }
}
#pragma warning restore 0109
#pragma warning restore 1591
