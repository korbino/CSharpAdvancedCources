using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestingEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            EventFire eventFire = new EventFire(); //publisher
            SubscriberForEvent subscriberForEvent = new SubscriberForEvent(); //subscriber
            SomeObject someObject = new SomeObject();

            eventFire.SomeObjectOperated += subscriberForEvent.OnSomeObjectOperated;

            eventFire.OperateSomeObject(someObject);


            Thread.Sleep(3000);
        }
    }
}
