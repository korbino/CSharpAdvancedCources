using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    public class ImageArgs : EventArgs
    {
        public string Status { get; set; }
        public Bitmap Image { get; set; }
    }
}
