using System;
using System.Collections;
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
            //cleaning process
            imageContainer = new ImageContainer();
            listBox1.Items.Clear();
            textBox1.Clear();

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
         
            //loading tags:
            try 
            {
                foreach (string s in imageContainer.imageTagList)
                {
                    listBox1.Items.Add(s);
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("EXCEPTION: loaded image was without tags");
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

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            imageContainer.imageTagList.Add(textBox1.Text);
            textBox1.Clear();           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //removing selected tags
            listBox1.BeginUpdate();
            ArrayList selectedItems = new ArrayList(listBox1.SelectedItems);

            foreach (string tagToRemove in selectedItems)
            {               
                listBox1.Items.Remove(tagToRemove);
                imageContainer.imageTagList.Remove(tagToRemove);              
            }
            listBox1.EndUpdate();
        }
    }
} 
