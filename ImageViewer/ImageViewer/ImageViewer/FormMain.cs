/*
 * TODO:
 * [-] create interface with events\deligate
 * [-] add to interface needed methods to show loaded images on pictureBoxMain
*/

using System;
using System.Windows.Forms;
using Controller;
using System.IO;
using System.Drawing;
using Model;
using System.Threading;
using System.Collections;

namespace ImageViewer
{
    public partial class FormMain : Form, IImageViewer
    {
        ImageController imageController = new ImageController();        

        public FormMain()
        {
            InitializeComponent();
        }
       
        private void Clear()
        {
            listBox_Tags.Items.Clear();
            listBox_ImageTitle.Items.Clear();
            textBox_Tags.Clear();
        }

        private void UpdatePictureBoxMain()
        {
            pictureBoxMain.Image = ImageContainer.GetInstance().image;
        }

        private void UpdateListBoxTags()
        {
            listBox_Tags.Items.Clear();
            foreach (string tag in ImageContainer.GetInstance().imageTagList)
            {
                listBox_Tags.Items.Add(tag);
            }
        }
        
        public void OnImageOperated(object obj, ImageArgs e)
        {
            MessageBox.Show(e.Status);
            //TODO: For some reason - once process wil go out from this method\class back to ImageOperation->ImageController->
            //And back to current class - pictureBoxMain.Image became as null again. 
            //Need to play AGAIN with onvoke?
            // pictureBoxMain.Image = e.Image;
        }       


        //UI elements:
        private void buttonOpenFromFile_Click(object sender, EventArgs e)
        {
            Clear();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Open Image";
                openFileDialog.Filter = "Image files (*.JPG; *.PNG; *.BIN)|*.JPG;*.PNG; *.BIN";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(openFileDialog.FileName).Equals(".BIN"))
                    {
                        //transfer to controller path to binary.
                        imageController.OpenImageFromBinary(File.Open(openFileDialog.FileName, FileMode.Open));
                        UpdatePictureBoxMain();
                        UpdateListBoxTags();
                    }
                    else
                    {
                        //transfer to controler path to jpeg-png image.
                        imageController.OpenImageFromJpegPngFile(openFileDialog.FileName.ToString());
                        UpdatePictureBoxMain();//need to change, once I'll understand how to work with Control.Invoke
                    }

                   // this.Controls.Add(pictureBoxMain); //toremove
                }
            } 
            
        }                     

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "BIN files (*.BIN)|*.BIN";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {                
                imageController.SaveFile(saveFileDialog.FileName);                             
            }
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            imageController.AddTag(textBox_Tags.Text);            
            UpdateListBoxTags();
            textBox_Tags.Clear();
        }

        private void buttonRemoveTag_Click(object sender, EventArgs e)
        {            
            listBox_Tags.BeginUpdate();//strting with it to avoid blinking of listBox
            ArrayList selectedItems = new ArrayList(listBox_Tags.SelectedItems);

            foreach (string tagToRemove in selectedItems)
            {
                listBox_Tags.Items.Remove(tagToRemove);//removing tag from ui
                imageController.RemoveTag(tagToRemove);//removing tag from object                
            }
            listBox_Tags.EndUpdate();
        }

        private void pictureBoxMain_Click(object sender, EventArgs e)
        {

        }    
}
}
