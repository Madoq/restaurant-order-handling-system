using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace restaurant_order_handling_system
{
    class Cash
    {
        Dictionary<int, Dish> menu;
        List<Dish> order = new List<Dish>();
        double cashTotal;
        public Cash(Dictionary<int, Dish> menu)
        {
            this.menu = menu;
        }
        private bool openCash = true;
        public void run()
        {
            while (openCash)
            {
                Console.WriteLine("Cash system");
                Console.WriteLine("1. Create new order");
                Console.WriteLine("2. Menu");
                Console.WriteLine("3. Show total mani");
                Console.WriteLine("4. Exit");

                char option;
                option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    case '1':
                        {
                            do
                            {
                                int menuItem;
                                menuItem = int.Parse(Console.ReadLine());
                                order.Add(menu[menuItem]);
                                cashTotal += menu[menuItem].Price;
                            } while (true);
                        }
                        break;
                    case '2':
                        {

                        }
                        break;
                    case '3':
                        {
                            
                        }
                        break;
                    case '4':
                        {
                            openCash = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("No such option ;<");
                        }
                        break;
                }
            }
        }
    }
}