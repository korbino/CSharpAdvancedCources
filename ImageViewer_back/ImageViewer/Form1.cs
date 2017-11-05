using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ImageViewer
{
    public partial class Form1 : Form
    {
        Controller controller = new Controller();

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

        private void button5_Click(object sender, EventArgs e)
        {
           string imageTitle = ShowDialog("Set image title", "Image Title");
           controller.WriteToDB(imageTitle, SerializeToXml(imageContainer));            

            // how to serialize\deserialized bitmap to\from xml: http://www.dotnetspider.com/resources/4759-XML-Serialization-C-Part-II-Images.aspx
            
        }

        public string SerializeToXml<T>(T value)
        {
            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(writer, value);
            return writer.ToString();            
        }

        public  ImageContainer DeseializeFromXmlToObject (string value)
        {

            ImageContainer objectToOut = new ImageContainer();
            XmlSerializer deserializer = new XmlSerializer(typeof(ImageContainer));
            StringReader sReader = new StringReader(value);
            XmlReader xmlReader = XmlReader.Create(sReader);            
            objectToOut = (ImageContainer)deserializer.Deserialize(txtReader);

            return objectToOut;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string imageSelection = null;
            string stringLoadedFromDBImage = null;

            try
            {
                imageSelection = listBox2.SelectedItem.ToString();
            }
            catch (System.NullReferenceException nullRefEx)
            {
                Console.WriteLine("DEBUG: " + nullRefEx.Message);
            }            

            if (imageSelection == null)
            {
                MessageBox.Show("Please choose image to load from DB");
            }
            else
            {
               stringLoadedFromDBImage = controller.GetImageFromDB(imageSelection);               
               imageContainer = DeseializeFromXmlToObject(stringLoadedFromDBImage);
               pictureBox1.Image = (Bitmap)imageContainer.image;


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
        }        

        private void button5_Click_1(object sender, EventArgs e)
        {
            //cleaning process            
            listBox2.Items.Clear();            

            List<string> listOfTitles = controller.GetListOfImagesFromDB();
            foreach (string s in listOfTitles)
            {
                listBox2.Items.Add(s);
            }

        }





        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
} 
