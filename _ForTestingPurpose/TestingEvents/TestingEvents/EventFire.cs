using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestingEvents
{
    class EventFire
    {
        public delegate void OperateSomeObjectEventHandler(object source, SomeObjectEventArgs args); //deligate
        public event OperateSomeObjectEventHandler SomeObjectOperated; //event

        public void OperateSomeObject(SomeObject obj)
        {
            Console.WriteLine("Operating with Object...");
            obj.NameOfObject = "Name_1";            

            OnSomeObjectOperated(obj);//fire event
        }


        //method, which describe how event will be fired
        protected void OnSomeObjectOperated(SomeObject obj)
        {
            Thread.Sleep(3000);
            if (SomeObjectOperated != null)
            {
                SomeObjectOperated(this, new SomeObjectEventArgs() { ObjectTitle = obj});
            }

        }
    }
}
