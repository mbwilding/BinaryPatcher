namespace PacketTracerConfigUnlock
{
    internal class Program
    {
        private static void Main()
        {
            Interface.Setup();
            Targets.Run();
            Interface.Finish();
        }
    }
}
