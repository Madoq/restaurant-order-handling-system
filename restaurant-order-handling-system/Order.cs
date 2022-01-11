using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_order_handling_system
{
    class Order
    {
        Dictionary<int, Dish> Positions = new Dictionary<int, Dish>();
        int PositionIndex = 1;
        public double Bill { get; set; } = 0;
        readonly Menu menu;
        public bool Closed = false;

        public Order(Menu menu)
        {
            this.menu = menu;
        }

        public void Run()
        {
            bool insideNewOrder = true;
            while (insideNewOrder)
            {
                Console.Clear();
                Console.WriteLine("New order");
                Console.WriteLine("1. Show order");
                Console.WriteLine("2. Add position");
                Console.WriteLine("3. Remove position");
                Console.WriteLine("X. Close order");
                Console.WriteLine("B. Back (order won't be saved)");

                char option;
                option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        {
                            Console.Clear();
                            this.OrderInfo();
                            Console.ReadKey();
                        }
                        break;
                    case '2':
                        {
                            this.AddPosition();
                        }
                        break;
                    case '3':
                        {
                            this.RemovePosition();
                        }
                        break;
                    case 'X':
                    case 'x':
                        {
                            this.Closed = true;
                            insideNewOrder = false;
                        }
                        break;
                    case 'B':
                    case 'b':
                        {
                            insideNewOrder = false;
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
        
        public void OrderInfo()
        {
            Console.WriteLine($"{this.Positions.Count} positions:");
            foreach (KeyValuePair<int, Dish> position in this.Positions)
            {
                Console.WriteLine($"{position.Key}. {position.Value.Name} - {position.Value.Price}$");
            }
            Console.WriteLine($"Bill: {this.Bill}$");
        }
        private void AddPosition()
        {
            bool insideMenu = true;
            bool insideCategory;
            string userInput;
            while (insideMenu)
            {
                insideCategory = true;
                Console.Clear();
                Console.WriteLine("Select category:");
                this.ShowMenuCategories();
                userInput = Console.ReadLine();
                if (userInput.ToLower() == "b")
                {
                    insideMenu = false;
                    break;
                }
                int option;
                if (!Int32.TryParse(userInput, out option) || !InputInRange(option, new int[] { 1, 2, 3, 4, 5, }))
                {
                    continue;
                }

                var categoryMenu = this.GetCategoryMenu(userInput);
                while (insideCategory)
                {
                    Console.Clear();
                    Console.WriteLine("Add to order:");
                    this.ShowCategoryMenu(categoryMenu);
                    userInput = Console.ReadLine();
                    if (userInput.ToLower() == "b")
                    {
                        insideCategory = false;
                        continue;
                    }
                    else if (!Int32.TryParse(userInput.ToString(), out option) || !InputInRange(option, categoryMenu.Keys.ToArray()))
                    {
                        continue;
                    }
                    Dish addedDish = menu.menu.FirstOrDefault(d => d.Key == option).Value;
                    this.Positions.Add(PositionIndex, addedDish);
                    this.PositionIndex++;
                    this.UpdateBill(addedDish.Price);
                    Kitchen.MenuContinue($"{addedDish.Name} was added to order.");
                }
            }
        }

        public void UpdateBill(double amount)
        {
            this.Bill += amount;
        }
        private void UpdatePositionsKeys()
        {
            Dictionary<int, Dish> newPositions = new Dictionary<int, Dish>();
            this.PositionIndex = 1;
            foreach (var position in this.Positions)
            {
                newPositions.Add(PositionIndex, position.Value);
                PositionIndex++;
            }
            this.Positions = newPositions;
        }

        private void RemovePosition()
        {
            bool insideRemove = true;
            char userInput;
            while (insideRemove)
            {
                Console.Clear();
                Console.WriteLine("Remove position:");
                this.ListPositions();
                Console.WriteLine("B. Back");
                userInput = Console.ReadKey().KeyChar;
                if (userInput == 'b')
                {
                    insideRemove = false;
                    break;
                }
                int option;
                if (!Int32.TryParse(userInput.ToString(), out option) || !InputInRange(option, this.Positions.Keys.ToArray()))
                {
                    continue;
                }
                var removedPosition = Positions.FirstOrDefault(d => d.Key == option);
                this.UpdateBill(-removedPosition.Value.Price);
                this.Positions.Remove(option);
                this.UpdatePositionsKeys();
            }
        }

        private void ListPositions()
        {
            foreach (var position in this.Positions)
            {
                Console.WriteLine($"{position.Key} {position.Value.Name}");
            }
        }

        private void ShowMenuCategories()
        {
            Console.WriteLine("1. Main Course");
            Console.WriteLine("2. Appetizer");
            Console.WriteLine("3. Drink");
            Console.WriteLine("4. Soup");
            Console.WriteLine("5. Dessert");
            Console.WriteLine("B. Back");
        }

        private void ShowCategoryMenu(Dictionary<int, Dish> category)
        {
            foreach (KeyValuePair<int, Dish> item in category)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Name}");
            }
            Console.WriteLine("B. Back");
        }

        private Dictionary<int, Dish> GetCategoryMenu(string option)
        {
            Dictionary<int, Dish> menuCategory = new Dictionary<int, Dish>();
            switch (option)
            {
                case "1":
                    menuCategory = menu.GetMenu(DishType.MainCourse);
                    break;
                case "2":
                    menuCategory = menu.GetMenu(DishType.Appetizer);
                    break;
                case "3":
                    menuCategory = menu.GetMenu(DishType.Drink);
                    break;
                case "4":
                    menuCategory = menu.GetMenu(DishType.Soup);
                    break;
                case "5":
                    menuCategory = menu.GetMenu(DishType.Dessert);
                    break;
                default:

                    break;
            }
            return menuCategory;
        }

        private bool InputInRange(int input, int[] options)
        {
            foreach (int option in options)
            {
                if (input == option)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
