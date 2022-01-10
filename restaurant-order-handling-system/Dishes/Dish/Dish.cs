using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_order_handling_system
{
    abstract class Dish : IisVegan
    {
        public string Name { get; }
        public double Price { get; }
        public List<Ingredient> Ingredients { get; }
        public int Weight { get; }
        public bool ifisvegan {get;set;}
        public Dish(string name, double price, List<Ingredient> ingredients, int weight)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
            Weight = weight;
        }

        internal string DishToString()
        {
            throw new NotImplementedException();
        }
        public void isvegan(Boolean bl )
        {
            ifisvegan = bl;
        }
         public String DishToStringSave()
        {
            return this.Name + ";" + Convert.ToString(this.Price) + ";" +IngredientsToString(this.Ingredients)+";"+this.Weight+";"+this.ifisvegan;
        }

        public String IngredientsToString(List<Ingredient> list)
        {
            String ingredients = "";
            foreach (Ingredient ingredient in list)
            {
                ingredients += ingredient.name;
                ingredients += ",";
            }
            ingredients = ingredients.Remove(ingredients.Length - 1);
            return ingredients;
        }
    }
}