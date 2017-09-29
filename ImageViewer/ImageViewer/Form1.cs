using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer
{
    public partial class Form1 : Form
    {
        ImageContainer imageContainer = new ImageContainer();
        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("test output");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Open Image";
                openFileDialog.Filter = "Image files (*.JPG; *.PNG; *.BIN)|*.JPG;*.PNG; *.BIN";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {                    
                    if (Path.GetExtension(openFileDialog.FileName).Equals(".BIN"))
                    {       
                        //deserialize
                        using (Stream stream = File.Open(openFileDialog.FileName, FileMode.Open))
                        {
                            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            imageContainer = (ImageContainer)binaryFormatter.Deserialize(stream);
                            pictureBox1.Image = (Bitmap)imageContainer.image;
                        }
                    }
                    else
                    {
                        pictureBox1.Image = new Bitmap(openFileDialog.FileName);                        
                        imageContainer.image = (Bitmap)pictureBox1.Image;
                    }                    

                    //(?not clear for me?) Add the new control to its parent's controls collection
                    this.Controls.Add(pictureBox1);
                }              
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "BIN files (*.BIN)|*.BIN";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string serilizationFile = saveFileDialog.FileName;
                //serialize
                using (Stream stream = File.Open(serilizationFile, FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bformatter.Serialize(stream, imageContainer);
                }               
            }
        }
    }
} 
