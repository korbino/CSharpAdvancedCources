using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingEvents
{
    public class SubscriberForEvent
    {
        public void OnSomeObjectOperated(object source, SomeObjectEventArgs e)
        {
            Console.WriteLine("Object was operated " + e.ObjectTitle);
        }
    }
}
