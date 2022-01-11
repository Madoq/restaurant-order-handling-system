using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_order_handling_system
{
    class Program
    {
        static void Main()
        {
            Kitchen kitchen = new Kitchen("Chicken House");
            kitchen.Run();
        }
    }
}