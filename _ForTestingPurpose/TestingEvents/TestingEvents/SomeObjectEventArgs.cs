using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingEvents
{
    public class SomeObjectEventArgs : EventArgs
    {
        public SomeObject ObjectTitle { get; set; }
    }
}
