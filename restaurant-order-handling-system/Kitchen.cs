﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using restaurant_order_handling_system.Dishes;

namespace restaurant_order_handling_system
{
    class Kitchen
    {
        Menu menu = new Menu();
        public Kitchen()
        {
            //seed example
            menu.Add(1, new MainCourse());
        }

        public void Run()
        {

            while (true)
            {
                Console.WriteLine("Restaurant Order Handling System");
                Console.WriteLine("1. Display Menu");
                Console.WriteLine("2. Add Dish");
                Console.WriteLine("3. Delete Dish");
                Console.WriteLine("4. Open Cash");
                Console.WriteLine("5. Exit");
                int option;
                try
                {
                    option = (int)Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                switch (option)
                {
                    case 1:
                        {

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
                            Cash cash = new Cash(menu);
                        }
                        break;
                    case 5:
                        {
                            Environment.Exit(0);
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