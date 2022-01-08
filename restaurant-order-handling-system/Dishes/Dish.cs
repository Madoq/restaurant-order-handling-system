using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_order_handling_system
{
    abstract class Dish
    {
        public string Name { get; }
        public double Price { get; }
        public List<Ingredient> Ingredients { get; }
        public int Weight { get; }

        public Dish(string name, double price, List<Ingredient> ingredients, int weight)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
            Weight = weight;
        }
    }
}