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
        public Dictionary<int,Dish> menu = new Dictionary<int, Dish>();

        public Menu()
        {

        }
        public Menu(Dictionary<int, Dish> menu)
        {
            this.menu = menu;
        }

        public Dictionary<int, Dish> GetMenu(DishType? dishType = null)
        {
            if (dishType == null) return menu;
            return menu.Where(d => d.Value.GetType().Name == dishType.ToString()).ToDictionary(d => d.Key, d => d.Value);
        }
        public Dictionary<int, Dish> GetVegan()
        {
            Dictionary<int, Dish> veganmenu = new Dictionary<int, Dish>();
            foreach(KeyValuePair<int, Dish> item in menu)
            {
                if(item.Value.ifisvegan==true)
                {
                    veganmenu.Add(item.Key,item.Value);
                }
            }
            return veganmenu;    
        }
    }

    public enum DishType
    {
        MainCourse,
        Dessert,
        Soup,
        Drink,
        Appetizer
    }
}