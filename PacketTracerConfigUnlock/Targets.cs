using System;
using System.IO;

namespace PacketTracerConfigUnlock
{
    public class Targets
    {
        public static void Run()
        {
            Patch
            (
                "Cisco Packet Tracer 7.2.2 (x86)",
                @"C:\Program Files (x86)\Cisco Packet Tracer 7.2.2\bin\PacketTracer7.exe",
                "E92B0100",
                0x1063AA4
            );
            Patch
            (
                "Cisco Packet Tracer 8.0.1 (x86)",
                @"C:\Program Files (x86)\Cisco Packet Tracer 8.0.1\bin\PacketTracer.exe",
                "E9380200",
                0x112EC6D
            );
            Patch
            (
                "Cisco Packet Tracer 7.2.2 (x64)",
                @"C:\Program Files\Cisco Packet Tracer 7.2.2\bin\PacketTracer7.exe",
                "E9490100",
                0x147B638
            );
            Patch
            (
                "Cisco Packet Tracer 8.0.1 (x64)",
                @"C:\Program Files\Cisco Packet Tracer 8.0.1\bin\PacketTracer.exe",
                "E9FA0200",
                0x1720076
            );
        }

        private static void Patch(string name, string path, string payload, int offset)
        {
            if (!File.Exists(path)) { return; }

            if (File.Exists(path + ".bak"))
            {
                Interface.Write(name + " has already been patched.", ConsoleColor.Blue);
                return;
            }

            TaskKill.Run(Path.GetFileNameWithoutExtension(path));

            File.Copy(path, path + ".bak");

            var fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            fileStream.Seek(offset, SeekOrigin.Begin);
            var patch = Converters.HexToBytes(payload);
            try
            {
                fileStream.Write(patch, 0, patch.Length);
            }
            catch (Exception e)
            {
                Interface.Write(e.ToString(), ConsoleColor.Red);
                throw;
            }
            fileStream.Dispose();

            Interface.Write("Successfully patched " + name + ".", ConsoleColor.Green);
        }
    }
}
