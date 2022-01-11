using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using restaurant_order_handling_system.Dishes;

namespace restaurant_order_handling_system
{
    class Kitchen
    {
        Menu menu = new Menu();
        LoadSave loadsave = new LoadSave();
        public Kitchen()
        {}

        public void Run()
        {
            menu = loadsave.LoadMenu("menu.txt");
            while (true)
            {
               Console.Clear();
                Console.WriteLine("Restaurant Order Handling System");
                Console.WriteLine("1. Display Menu");
                Console.WriteLine("2. Add Dish");
                Console.WriteLine("3. Delete Dish");
                Console.WriteLine("4. Open Cash");
                Console.WriteLine("5. Save Menu changes");
                Console.WriteLine("6. Exit");
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
                            MenuContinue();
                        }
                        break;
                    case '2':
                        {
                            Console.Clear();
                            Console.WriteLine("Select the type of dish you wish to add:");
                            Console.WriteLine("1. Main Course");
                            Console.WriteLine("2. Appetizer");
                            Console.WriteLine("3. Drink");
                            Console.WriteLine("4. Soup");
                            Console.WriteLine("5. Dessert");
                            Console.WriteLine("B. Back");

                            option = Console.ReadKey().KeyChar;
                            if (option == 'b' || option == 'B') break;
                            Console.Clear();

                            string dishName = "";
                            double price;
                            int weight;
                            List<Ingredient> ingredients = new List<Ingredient>();

                            while(dishName == "")
                            {
                                Console.WriteLine("Dish Name: ");
                                dishName = Console.ReadLine();
                            }
                            Console.WriteLine("Price: ");
                            while (!double.TryParse(Console.ReadLine(), out price))
                            {
                                Console.WriteLine("Price invalid.");
                            }
                            Console.WriteLine("Weight: ");
                            while (!int.TryParse(Console.ReadLine(), out weight))
                            {
                                Console.WriteLine("Weight invalid.");
                            }
                            Console.WriteLine("Type in the ingredient list seperated by a comma [,]:");
                            foreach (string ingredientName in Console.ReadLine().Split(","))
                            {
                                ingredients.Add(new Ingredient(ingredientName));
                            }
                            
                            switch (option)
                            {
                                case '1':
                                    menu.menu.Add(loadsave.dishIndex++, new MainCourse(dishName, price, ingredients, weight));
                                    break;
                                case '2':
                                    menu.menu.Add(loadsave.dishIndex++, new Appetizer(dishName, price, ingredients, weight));
                                    break;
                                case '3':
                                    menu.menu.Add(loadsave.dishIndex++, new Drink(dishName, price, ingredients, weight));
                                    break;
                                case '4':
                                    menu.menu.Add(loadsave.dishIndex++, new Soup(dishName, price, ingredients, weight));
                                    break;
                                case '5':
                                    menu.menu.Add(loadsave.dishIndex++, new Dessert(dishName, price, ingredients, weight));
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case '3':
                        {
                            Console.Clear();
                            Console.WriteLine("Type the dish number you wish to delete: ");
                            if(int.TryParse(Console.ReadLine(), out int dishIndex))
                            {
                                if(menu.menu.ContainsKey(dishIndex))
                                {
                                    menu.menu.Remove(dishIndex);
                                    MenuContinue("Dish removed.");
                                }
                                else MenuContinue("Dish not found.");
                            }
                            else MenuContinue("Invalid dish number.");
                        }
                        break;
                    case '4':
                        {
                            //Cash cash = new Cash(menu);
                        }
                        break;
                    case '5':
                        {
                            loadsave.Savemenu(menu, "menu.txt");
                        }
                        break;
                    case '6':
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
        public static void MenuContinue(string input = null)
        {
            Console.WriteLine(input);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
