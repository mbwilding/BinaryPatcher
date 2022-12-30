using System.Diagnostics;

namespace BinaryPatcher;

public static class TaskKill
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