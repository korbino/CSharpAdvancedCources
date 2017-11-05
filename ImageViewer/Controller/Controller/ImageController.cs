using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Drawing;

namespace Controller
{
    public class ImageController
    {
        ImageOperations imageOperations = ImageOperations.GetInstance();

        public void OpenImageFromBinary(Stream stream)
        {
            imageOperations.DeserializeImageFromBin(stream);
        }

        public void OpenImageFromJpegPngFile(string path)
        {
            imageOperations.OpenImageFromJpgPng(path);
        }

        public void SaveFile(String saveFilePath)
        {
            imageOperations.SaveFile(saveFilePath);
        }

        public void AddTag(string tag)
        {
            imageOperations.AddTag(tag);
        }

        public void RemoveTag(string tagToRemove)
        {
            imageOperations.RemoveTag(tagToRemove);
        }
    }
}
