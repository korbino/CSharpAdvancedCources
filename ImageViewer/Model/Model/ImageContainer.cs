using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;


namespace Model
{
    [Serializable]

    public class ImageContainer
    {
        public Bitmap image;
        public List<string> imageTagList = new List<string>();

        //singltone implemetation
        private static ImageContainer instance = null;
        private ImageContainer() { }
        public static ImageContainer GetInstance()
        {
            if (instance == null)
            {
                instance = new ImageContainer();
                return instance;
            }
            else
            {
                return instance;
            }
        }


    }
}
