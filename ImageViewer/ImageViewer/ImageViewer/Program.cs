using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace ImageViewer
{
    static class Program
    {        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //defining publisher, subscriber and linking 
           ImageOperations imageOperations = ImageOperations.GetInstance();//publisher
           FormMain formMain = new FormMain(); //subscriber
           imageOperations.ImageOperated += formMain.OnImageOperated;

            Application.Run(new FormMain());          

           
        }
    }
}
