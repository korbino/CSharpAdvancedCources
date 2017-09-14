using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileReaderWithThreads
{
    public class Menu        
    {       
        private bool isExit = false;
        Logic logic = new Logic();
        
        public void RunMainMenu()
        {
            while (!isExit)
            {
                Console.WriteLine("1. Read data file.");
                Console.WriteLine("2. Operate with 3 threads");
                Console.WriteLine("3. Write result to output file");
                Console.WriteLine("4. Exit");
                Console.WriteLine("\nChoose your destiny:");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        logic.ReadDataFromFile();                        
                        break;
                    case "2":
                        logic.RunOperationWithThreads();                       
                        break;
                    case "3":
                        logic.WriteResultInOutputFile();
                        break;
                    case "4":
                        Logger.INFO("Bye, bye....");
                        Thread.Sleep(1500);
                        isExit = true;
                        break;
                    default:
                        Logger.WARN("You enetered not correct value, please enter it again.");                        
                        break;                       
                }

            }
        }
    }
}
