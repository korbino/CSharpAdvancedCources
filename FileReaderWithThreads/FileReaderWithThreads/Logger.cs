using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReaderWithThreads
{
    static class Logger
    {
        public static void INFO (string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nINFO: {0}\n", message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void DEBUG (string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nDEBUG: {0}\n", message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WARN(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nWARN: {0}\n", message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void ERROR (string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERROR: {0}\n", message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
