using System;
using System.Collections.Generic;
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
                new Dictionary<long, string>()
                {
                    {0x1063AA4, "E92B0100"},    // Unlock config tab
                    {0x16AAB0D, "E9530100"}     // Speed up loading times
                }
            );
            Patch
            (
                "Cisco Packet Tracer 8.0.1 (x86)",
                @"C:\Program Files (x86)\Cisco Packet Tracer 8.0.1\bin\PacketTracer.exe",
                new Dictionary<long, string>()
                {
                    {0x112EC6D, "E9380200"},    // Unlock config tab
                    {0x191806D, "E9FF0600"}     // Speed up loading times
                }
            );
            Patch
            (
                "Cisco Packet Tracer 7.2.2 (x64)",
                @"C:\Program Files\Cisco Packet Tracer 7.2.2\bin\PacketTracer7.exe",
                new Dictionary<long, string>()
                {
                    {0x147B638, "E9490100"},    // Unlock config tab
                    {0x1C58604, "E9650500"}     // Speed up loading times
                }
            );
            Patch
            (
                "Cisco Packet Tracer 8.0.1 (x64)",
                @"C:\Program Files\Cisco Packet Tracer 8.0.1\bin\PacketTracer.exe",
                new Dictionary<long, string>()
                {
                    {0x1720076, "E9FA0200"},    // Unlock config tab
                    {0x218B564, "E9820800"}     // Speed up loading times
                }
            );
        }

        private static void Patch(string name, string path, Dictionary<long, string> payloads)
        {
            if (!File.Exists(path)) { return; }

            if (File.Exists(path + ".bak"))
            {
                Interface.Write(name + " has already been patched.", ConsoleColor.Blue);
                return;
            }

            TaskKill.Run(Path.GetFileNameWithoutExtension(path));

            File.Copy(path, path + ".bak");

            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.Write);

            foreach (var entry in payloads)
            {
                fileStream.Seek(entry.Key, SeekOrigin.Begin);
                var patch = Converters.HexToBytes(entry.Value);
                try
                {
                    fileStream.Write(patch, 0, patch.Length);
                }
                catch (Exception e)
                {
                    Interface.Write(e.ToString(), ConsoleColor.Red);
                    throw;
                }
            }

            fileStream.Dispose();

            Interface.Write("Successfully patched " + name + ".", ConsoleColor.Green);
        }
    }
}
