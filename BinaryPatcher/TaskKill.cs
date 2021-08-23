using System.Diagnostics;

namespace BinaryPatcher
{
    public class TaskKill
    {
        public static void Run(string name)
        {
            foreach (var process in Process.GetProcessesByName(name))
            {
                process.Kill();
                process.WaitForExit();
            }
        }
    }
}
