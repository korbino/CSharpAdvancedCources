using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileReaderWithThreads
{
   class Utils
    {
       private  string INPUT_FILE;
       private  string OUTPUT_FILE;
       private  string[] globalStringArray;
       private Object locker = new Object();

       public  void ReadDataFromFile(string inputFile = "inputFile.txt", string outputFile = "outputFile.txt")
       {
           INPUT_FILE = inputFile;       
           OUTPUT_FILE = outputFile;
           globalStringArray = File.ReadAllLines(INPUT_FILE);   // read file itself         
           Logger.INFO("Data was readed from intput file");           
       }       

       public  int GetNumberOfLinesFromReadedFile()
       {
           try
           {
               return globalStringArray.Length;
           }
           catch (Exception e)
           {
               Logger.ERROR("Woops... You tried to operate with threads, but without reading input file before.");               
               return 0;
           }          
       }
        
       public  void ChangeCaseOfStringLinesToOppositeWithOutputToFile(int min, int max, ref List<string> convertedStringsList)
        {                        
            convertedStringsList = new List<string>();            
           
            //convert cases to opposite and save it to tmp array:
            for (int i = min; i < max; i++)
            {
                string line = new string(
                        globalStringArray[i].Select(c => char.IsLetter(c) ? (char.IsUpper(c) ?
                                        char.ToLower(c) : char.ToUpper(c)) : c).ToArray());
                convertedStringsList.Add(line);
            }            
        }

       public void WriteResultToTheOutputFile(List<string> list)
       {
           Logger.INFO("Write process is started, please wait...");           
           foreach (string line in list)
           {
               File.AppendAllText(OUTPUT_FILE, line + "\n");
           }
           Logger.INFO("Write process completed.");           
       }

    }
}
