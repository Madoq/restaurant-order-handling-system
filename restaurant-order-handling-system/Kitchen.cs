using System;
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
        int dishIndex = 1;
        public Kitchen()
        {
            //seed example
            menu.menu.Add(dishIndex++, new MainCourse("Chicken Dish", 25, new List<Ingredient>(), 1));
            menu.menu.Add(dishIndex++, new Appetizer("Chicken Wings", 25, new List<Ingredient>(), 1));
            menu.menu.Add(dishIndex++, new Drink("Chicken Fat", 25, new List<Ingredient>(), 1));
            menu.menu.Add(dishIndex++, new Soup("Chicken Soup", 25, new List<Ingredient>(), 1));
            menu.menu.Add(dishIndex++, new Dessert("Chicken Chocolate", 25, new List<Ingredient>(), 1));
            menu.menu.Add(dishIndex++, new MainCourse("Duck Dish", 25, new List<Ingredient>(), 1));
            menu.menu.Add(dishIndex++, new Appetizer("Duck Wings", 25, new List<Ingredient>(), 1));
            menu.menu.Add(dishIndex++, new Drink("Duck Fat", 25, new List<Ingredient>(), 1));
            menu.menu.Add(dishIndex++, new Soup("Duck Soup", 25, new List<Ingredient>(), 1));
            menu.menu.Add(dishIndex++, new Dessert("Duck Chocolate", 25, new List<Ingredient>(), 1));
        }

        public void Run()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Restaurant Order Handling System");
                Console.WriteLine("1. Display Menu");
                Console.WriteLine("2. Add Dish");
                Console.WriteLine("3. Delete Dish");
                Console.WriteLine("4. Open Cash");
                Console.WriteLine("5. Exit");

                char option;
                option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    case '1':
                        {
                            Console.Clear();
                            Console.WriteLine("1. All");
                            Console.WriteLine("2. Main Course");
                            Console.WriteLine("3. Appetizer");
                            Console.WriteLine("4. Drink");
                            Console.WriteLine("5. Soup");
                            Console.WriteLine("6. Dessert");
                            Console.WriteLine("B. Back");
                            switch(Console.ReadKey().KeyChar)
                            {
                                case '1':
                                    DisplayMenu(menu.GetMenu());
                                    break;
                                case '2':
                                    DisplayMenu(menu.GetMenu(DishType.MainCourse));
                                    break;
                                case '3':
                                    DisplayMenu(menu.GetMenu(DishType.Appetizer));
                                    break;
                                case '4':
                                    DisplayMenu(menu.GetMenu(DishType.Drink));
                                    break;
                                case '5':
                                    DisplayMenu(menu.GetMenu(DishType.Soup));
                                    break;
                                case '6':
                                    DisplayMenu(menu.GetMenu(DishType.Dessert));
                                    break;
                                default:
                                    Console.Clear();
                                    break;
                            }
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();

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
                            //Cash cash = new Cash(menu);
                        }
                        break;
                    case '5':
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

        public static void DisplayMenu(Dictionary<int, Dish> menu)
        {
            Console.Clear();
            foreach(KeyValuePair<int, Dish> item in menu)
                Console.WriteLine($"{item.Key}: {item.Value.Name}");
        }

    }
}
