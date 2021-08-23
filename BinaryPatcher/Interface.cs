using System;

namespace BinaryPatcher
{
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
            Write("\nPress any key to exit.", ConsoleColor.Cyan);
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
