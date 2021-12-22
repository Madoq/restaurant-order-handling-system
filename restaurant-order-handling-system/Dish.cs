using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_order_handling_system
{
    abstract class Dish
    {
        string name;
        int price;
        List<string> Ingredients = new List<string>();
        int weight;
    }
}
