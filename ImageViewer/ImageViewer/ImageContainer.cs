using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    [Serializable]
    class ImageContainer
    {
       public Bitmap image;
       public List<string> imageTagList = new List<string>();
    }
}
