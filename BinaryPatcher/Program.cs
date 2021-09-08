namespace BinaryPatcher
{
    class Program
    {
        static void Main()
        {
            Interface.Setup();
            Targets.Run();
            Interface.Finish();
        }
    }
}
