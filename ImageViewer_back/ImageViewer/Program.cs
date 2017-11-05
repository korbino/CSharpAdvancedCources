//TODO:
/*[+] Add DB to project
 *[-] DB should be in normal form
 *[+] Save image with tags to the DB (Ado.net)
 *[-] Load image from DB
 *[-] Tags should be normalized
 *[-] Apply MVC pathern to the project
 *[-] Add interface for the View
 *[-] Separate all moduls for the DLLs
 *[-] add restriction for same name of image
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Application.Run(new Form1());
        }
    }
}
