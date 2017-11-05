using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageViewer;
using System.Drawing;
using System.Threading;

namespace Model
{           
    public class ImageOperations
    {
        private static ImageOperations insatnce = null;
        public delegate void ImageOperateEventHandler(object obj, ImageArgs e);//deligate
        public event ImageOperateEventHandler ImageOperated;//event        
        ImageContainer imageContainer = ImageContainer.GetInstance();

        //define this class like singletone
        private ImageOperations(){}

        public static ImageOperations GetInstance()
        {
            if(insatnce == null)
            {
                insatnce = new ImageOperations();
                return insatnce;
            }
            else
            {
                return insatnce;
            }
        }

        public void DeserializeImageFromBin(Stream stream)
        {
            ImageContainer tmpImageContainer;
            //deserialize
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            tmpImageContainer = (ImageContainer)binaryFormatter.Deserialize(stream);
            imageContainer.image = tmpImageContainer.image;
            imageContainer.imageTagList = tmpImageContainer.imageTagList;

            //fire event.
            OnImageOperatedSuccess();
            
        }

        public void OpenImageFromJpgPng(string path)
        {
            imageContainer.image = new Bitmap (path);
            
            //fire event
            OnImageOperatedSuccess();
        }

        //method, which describe - how event will be fired to the ImageView form
        protected void OnImageOperatedSuccess()
        {
            if (ImageOperated != null)
            {                
                ImageOperated(this, new ImageArgs()
                {
                    Status = "Image Loaded Successfully",
                    Image = imageContainer.image
                    
                });
            }
        }

        //save file to BIN:
        public void SaveFile(string saveFilePath)
        {
            //serialize
            Stream stream = File.Open(saveFilePath, FileMode.Create);
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bformatter.Serialize(stream, imageContainer);   
        }

        //adding tag:
        public void AddTag(string tag)
        {            
            imageContainer.imageTagList.Add(tag);            
        }

        //remove tag from object:
        public void RemoveTag(string tagToRemove)
        {
            imageContainer.imageTagList.Remove(tagToRemove);
        }
    }
}
