using Photon.Deterministic;
using Quantum;
using UnityEngine;
using Input = Quantum.Input;
using UnityInput = UnityEngine.Input;

public class TanksInput : MonoBehaviour
{
    private void OnEnable()
    {
        QuantumCallback.Subscribe(this, (CallbackPollInput callback) => PollInput(callback));
    }

    public void PollInput(CallbackPollInput callback)
    {
        var quantumInput = new Input();

        quantumInput.Left = UnityInput.GetKey(KeyCode.A) || UnityInput.GetKey(KeyCode.LeftArrow);
        quantumInput.Right = UnityInput.GetKey(KeyCode.D) || UnityInput.GetKey(KeyCode.RightArrow);
        quantumInput.Up = UnityInput.GetKey(KeyCode.W) || UnityInput.GetKey(KeyCode.UpArrow);
        quantumInput.Down = UnityInput.GetKey(KeyCode.S) || UnityInput.GetKey(KeyCode.DownArrow);
        quantumInput.Fire = UnityInput.GetKey(KeyCode.Space);
        
        callback.SetInput(quantumInput, DeterministicInputFlags.Repeatable);
    }
}
