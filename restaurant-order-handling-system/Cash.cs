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
        double static cashTotal;
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
                int option;
                try
                {
                    option = (int)Console.ReadLine();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                switch (option)
                {
                    case 1:
                        {
                            do 
                            { 
                                int menuItem;
                                menuItem = (int)Console.ReadLine();
                                order.Add(menu[menuItem]);
                                cashTotal += menu[menuItem].Price;
                            }while()
                        }
                        break;
                    case 2:
                        {

                        }
                        break;
                    case 3:
                        {
                            
                        }
                        break;
                    case 4:
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