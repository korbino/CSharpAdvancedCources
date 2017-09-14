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
        Utils utils = new Utils();//in util present main methods to read and how to transform the text.
        private int oneThirdNumber;             
        private List<string> resultFromFirstThread = new List<string> ();
        private List<string> resultFromSecondThread = new List<string>();
        private List<string> resultFromThirdThread = new List<string>();
        private List<String> resultListFinal;
        private const string OUTPUT_FILE = "outputFile.txt";        


        public void ReadDataFromFile(){
            utils.ReadDataFromFile();
            oneThirdNumber = utils.GetNumberOfLinesFromReadedFile() / 3; //finding one third number divider
        }
        
        public void RunOperationWithThreads (){
            //Celean operations:
            File.Create(OUTPUT_FILE).Close();         
          
            //running 3 new threads for the operating with 1\3 file part each, and convert the case to inverse:
            Logger.INFO("Starting to inverse chars to opposit case.");
            
            Thread firstThread = new Thread(() => utils.ChangeCaseOfStringLinesToOppositeWithOutputToFile(0, oneThirdNumber, ref resultFromFirstThread));
            Thread secondThread = new Thread(() => utils.ChangeCaseOfStringLinesToOppositeWithOutputToFile(oneThirdNumber, oneThirdNumber * 2, ref resultFromSecondThread));
            Thread thirdThread = new Thread(() => utils.ChangeCaseOfStringLinesToOppositeWithOutputToFile(oneThirdNumber * 2, utils.GetNumberOfLinesFromReadedFile(),ref resultFromThirdThread));            

            firstThread.Start();
            secondThread.Start();
            thirdThread.Start();
            
            //check for thread completed:
            firstThread.Join();
            secondThread.Join();
            thirdThread.Join();

            Logger.INFO("Inverse process completed!");

            resultListFinal = new List<string>();//clean result

            //concatinate all result lists to one.                                   
            resultListFinal = resultListFinal.Concat(resultFromFirstThread).Concat(resultFromSecondThread).Concat(resultFromThirdThread).ToList();

            //clean process:
            resultFromFirstThread = new List<string>();
            resultFromSecondThread = new List<string>();
            resultFromThirdThread = new List<string>();         
        }

        public void WriteResultInOutputFile()
        {
            utils.WriteResultToTheOutputFile(resultListFinal);
        }
    }
}
