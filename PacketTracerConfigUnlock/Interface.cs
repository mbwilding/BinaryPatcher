using System;

namespace PacketTracerConfigUnlock
{
    public class Interface
    {
        private const string Banner =
        @"
            ______               _           _     _____                                
            | ___ \             | |         | |   |_   _|                               
            | |_/ /  __ _   ___ | | __  ___ | |_    | |   _ __   __ _   ___   ___  _ __ 
            |  __/  / _` | / __|| |/ / / _ \| __|   | |  | '__| / _` | / __| / _ \| '__|
            | |    | (_| || (__ |   < |  __/| |_    | |  | |   | (_| || (__ |  __/| |   
            \_|     \__,_| \___||_|\_\ \___| \__|   \_/  |_|    \__,_| \___| \___||_|   
                                                                                        
                                                                                        
             _____                 __  _          _   _         _               _       
            /  __ \               / _|(_)        | | | |       | |             | |      
            | /  \/  ___   _ __  | |_  _   __ _  | | | | _ __  | |  ___    ___ | | __   
            | |     / _ \ | '_ \ |  _|| | / _` | | | | || '_ \ | | / _ \  / __|| |/ /   
            | \__/\| (_) || | | || |  | || (_| | | |_| || | | || || (_) || (__ |   <    
             \____/ \___/ |_| |_||_|  |_| \__, |  \___/ |_| |_||_| \___/  \___||_|\_\   
                                           __/ |                                        
                                          |___/                                         

        ";

        public static void Setup()
        {
            Console.Title = "Packet Tracer Config Unlock";
            Console.SetWindowSize(100, 26);
            Write(Banner, ConsoleColor.Magenta);
        }

        public static void Finish()
        {
            Write("\nPress any key to exit.", ConsoleColor.Cyan);
            Console.ReadKey();
        }

        public static void Write(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
