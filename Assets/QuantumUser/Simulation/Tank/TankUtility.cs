namespace Quantum
{
    public static unsafe class TankUtility
    {
        public static Input* RetrievePlayerInput(Frame frame, EntityRef entity)
        {
            Input* input = default;

            if (frame.Unsafe.TryGetPointer(entity, out PlayerLink* playerLink))
            {
                input = frame.GetPlayerInput(playerLink->PlayerRef);
            }

            return input;
        }
    }
}
