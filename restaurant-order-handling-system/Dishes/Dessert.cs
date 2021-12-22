using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_order_handling_system.Dishes
{
    class Dessert : Dish
    {
        public Dessert(string name,double price, List<Ingredient> ingredients, int weight) : base(name, price, ingredients, weight)
        {
               
        }
    }
}