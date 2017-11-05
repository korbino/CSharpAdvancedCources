using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImageViewer
{
    [Serializable]
    
    public class ImageContainer 
    {
       public Bitmap image;
       public List<string> imageTagList = new List<string>();

       // Set serialization to IGNORE this property
       // because the 'PictureByteArray' property
       // is used instead to serialize
       // the 'Picture' Bitmap as an array of bytes.
       [XmlIgnore]
       public Bitmap Source
       {
           get { return image; }
           set { image = value; }
       }
       // Set PictureByteArray Property 
       // to be an attribute of the Picture node 
       [XmlAttribute("image")]
       public byte[] PictureByteArray
       {
           get
           {
               //get a TypeConverter object for converting Bitmap to bytes
               TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
               return (byte[])converter.ConvertTo(image, typeof(byte[]));
           }
           set
           {
               image = new Bitmap(new MemoryStream(value));
           }
       }
    }
}
