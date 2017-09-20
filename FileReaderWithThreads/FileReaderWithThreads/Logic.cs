using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileReaderWithThreads
{
    public class Logic
    {        
        private int arraySplittingNumber;             
        private List<string> resultFromFirstThread = new List<string> ();
        private List<string> resultFromSecondThread = new List<string>();
        private List<string> resultFromThirdThread = new List<string>();        
        private string[] readedStringArray;
        private string OUTPUT_FILE = "outputFile.txt";
        private string INPUT_FILE = "inputFile.txt";
        private StringBuilder strinBuilder = new StringBuilder();
        private bool isFileWasAlreadyWritten;

        public void ReadDataFromFile(){            
            readedStringArray = File.ReadAllLines(INPUT_FILE);
            arraySplittingNumber = readedStringArray.Length / 3;
            Logger.INFO("Data was readed from intput file");
        }
        
        public void RunOperationWithThreads (){                             
            //running 3 new threads for the operating with 1\3 file part each, and convert the case to inverse:
            Logger.INFO("Starting to inverse chars to opposit case.");
            
            Thread firstThread = new Thread(() => ChangeCaseOfStringLinesToOpposite(0, arraySplittingNumber, ref resultFromFirstThread));
            Thread secondThread = new Thread(() => ChangeCaseOfStringLinesToOpposite(arraySplittingNumber, arraySplittingNumber * 2, ref resultFromSecondThread));
            Thread thirdThread = new Thread(() => ChangeCaseOfStringLinesToOpposite(arraySplittingNumber * 2, readedStringArray.Length,ref resultFromThirdThread));            

            firstThread.Start();
            secondThread.Start();
            thirdThread.Start();
            
            //check for thread completed:
            firstThread.Join();
            secondThread.Join();
            thirdThread.Join();

            Logger.INFO("Inverse process completed!");

            strinBuilder.
                Append(String.Join("\n", resultFromFirstThread)).Append("\n").
                Append(String.Join("\n", resultFromSecondThread)).Append("\n").
                Append(String.Join("\n", resultFromThirdThread));            
        }             

        public void WriteResultToTheOutputFile()
        {             
            if (!isFileWasAlreadyWritten)
            {
                Logger.INFO("Write process is started, please wait...");
                File.WriteAllText(OUTPUT_FILE, strinBuilder.ToString());
                Logger.INFO("Write process completed.");
                isFileWasAlreadyWritten = true;
            }
            else
            {
                Logger.WARN("The output file was already written.");
            }           
        }
        

        
        
        //PRIVATE section:
        private void ChangeCaseOfStringLinesToOpposite(int min, int max, ref List<string> tmpList)
        {            
            //convert cases to opposite and save it to tmp array:
            for (int i = min; i < max; i++)
            {             
                tmpList.Add((new string(
                        readedStringArray[i].Select(c => char.IsLetter(c) ? (char.IsUpper(c) ?
                                        char.ToLower(c) : char.ToUpper(c)) : c).ToArray())));
                
            }
        }
    }
}
