using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using restaurant_order_handling_system.Dishes;
namespace restaurant_order_handling_system
{
    class Menu
    {
        Dictionary<int,Dish> menu = new Dictionary<int, Dish>();
        public void MenuShow(DishType? dishType)
        {

        }
    }
    enum DishType
    {
        MainCourse,
        Dessert
    }
}