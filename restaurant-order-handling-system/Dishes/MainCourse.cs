using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_order_handling_system.Dishes
{
    class MainCourse : Dish
    {
        public MainCourse(string name,double price, List<Ingredient> ingredients, int weight) : base(name, price, ingredients, weight)
        {
               
        }
    }
}
