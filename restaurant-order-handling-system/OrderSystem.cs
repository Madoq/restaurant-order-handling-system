using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_order_handling_system
{
    class OrderSystem
    {
        readonly Menu menu = new Menu();
        List<Order> Orders = new List<Order>();
        double ordersBalance = 0;
        public OrderSystem(Menu menu)
        {
            this.menu = menu;
        }

        public void Run()
        {
            bool insideOrder = true;
            while (insideOrder)
            {
                Console.Clear();
                Console.WriteLine("Order system");
                Console.WriteLine("1. New order");
                Console.WriteLine("2. Closed orders");
                Console.WriteLine("B. Back");

                char option;
                option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        {
                            Order newOrder = new Order(menu);
                            newOrder.Run();
                            if (newOrder.Closed)
                            {
                                Orders.Add(newOrder);
                            }
                            this.UpdateCashBalance(newOrder.Bill);
                        }
                        break;
                    case '2':
                        {
                            bool insideClosedOrders = true;
                            while (insideClosedOrders)
                            {
                                Console.Clear();
                                Console.WriteLine("Closed orders");
                                Console.WriteLine("1. List orders");
                                Console.WriteLine("B. Back");

                                option = Console.ReadKey().KeyChar;
                                switch (option)
                                {
                                    case '1':
                                        {
                                            Console.Clear();
                                            this.ListOrders();
                                            Console.ReadKey();
                                        }
                                        break;
                                    case 'B':
                                    case 'b':
                                        {
                                            insideClosedOrders = false;
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
                        break;
                    case 'B':
                    case 'b':
                        {
                            insideOrder = false;
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

        private void ListOrders()
        {
            Console.WriteLine("Closed orders:");
            for (int i = 0; i < Orders.Count; i++)
            {
                Console.WriteLine($"{i + 1} order");
                Orders[i].OrderInfo();
                Console.WriteLine();
            }
        }

        private void UpdateCashBalance(double addedPositionPrice)
        {
            this.ordersBalance += addedPositionPrice;
        }

        public void GetBalance()
        {
            Console.WriteLine($"Cash balance: {ordersBalance}$");
        }
    }
}
