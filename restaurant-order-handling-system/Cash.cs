using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace restaurant_order_handling_system
{
    class Cash
    {
        readonly OrderSystem orderSystem;
        readonly Menu menu = new Menu();
        public Cash(Menu menu)
        {
            this.menu = menu;
            this.orderSystem = new OrderSystem(menu);
        }

        public void Run()
        {
            bool openCash = true;
            while (openCash)
            {
                Console.Clear();
                Console.WriteLine("Cash system");
                Console.WriteLine("1. Order system");
                Console.WriteLine("2. Money balance");
                Console.WriteLine("X. Exit");

                char option;
                option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    case '1':
                        {
                            orderSystem.Run();
                        }
                        break;
                    case '2':
                        {
                            Console.Clear();
                            orderSystem.GetBalance();
                            Console.ReadKey();
                        }
                        break;
                    case 'X':
                    case 'x':
                        {
                            openCash = false;
                        }
                        break;
                    default:
                        {
                            Console.Clear();
                        }
                        break;
                }
            }
        }
    }
}