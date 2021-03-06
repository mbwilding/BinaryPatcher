using System;

namespace BinaryPatcher
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]

    public class Interface
    {
        private const string Banner =
        @"
    ██████╗ ██╗███╗   ██╗ █████╗ ██████╗ ██╗   ██╗    ██████╗  █████╗ ████████╗ ██████╗██╗  ██╗███████╗██████╗ 
    ██╔══██╗██║████╗  ██║██╔══██╗██╔══██╗╚██╗ ██╔╝    ██╔══██╗██╔══██╗╚══██╔══╝██╔════╝██║  ██║██╔════╝██╔══██╗
    ██████╔╝██║██╔██╗ ██║███████║██████╔╝ ╚████╔╝     ██████╔╝███████║   ██║   ██║     ███████║█████╗  ██████╔╝
    ██╔══██╗██║██║╚██╗██║██╔══██║██╔══██╗  ╚██╔╝      ██╔═══╝ ██╔══██║   ██║   ██║     ██╔══██║██╔══╝  ██╔══██╗
    ██████╔╝██║██║ ╚████║██║  ██║██║  ██║   ██║       ██║     ██║  ██║   ██║   ╚██████╗██║  ██║███████╗██║  ██║
    ╚═════╝ ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝       ╚═╝     ╚═╝  ╚═╝   ╚═╝    ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝
        ";

        public static void Setup()
        {
            Console.Title = "Binary Patcher";
            Console.SetWindowSize(115, 15);
            Write(Banner, ConsoleColor.Magenta);
        }

        public static void Finish()
        {
            Write("\n | ≡ | Press any key to exit.", ConsoleColor.Cyan);
            Console.ReadKey();
        }

        public static void Write(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
