using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace restaurant_order_handling_system.Dishes
{
    internal class LoadSave
    {
        public Menu LoadMenu (string filename)
        {
             Menu menu = new Menu();
            try
            {
               
                int indx = 1;
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName+'/'+filename;
            Console.WriteLine("\n"+path);
            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            using var sr = new StreamReader(fs, Encoding.UTF8);
            string line = String.Empty;
            while ((line = sr.ReadLine()) != null)
            {
                string[] subs = line.Split(";");
                int number = Int32.Parse(subs[0]);
                string typeclass = subs[1];
                string name = subs[2];
                int price = Int32.Parse(subs[3]);
                string[] ingredients = subs[4].Split(",");
                int weight = Int32.Parse(subs[5]);
                //Console.WriteLine(typeclass+" "+name+" "+price+" "+String.Join(", ",ingredients)+" "+weight);
                if (typeclass == "Appetizer")
                {
                    Appetizer dish = new Appetizer(name, Convert.ToDouble(price),casttolist(ingredients),weight);
                    menu.menu.Add(number,dish);
                }
                else if (typeclass == "Dessert")
                {
                    Dessert dish = new Dessert(name, Convert.ToDouble(price),casttolist(ingredients),weight);
                    menu.menu.Add(number, dish);
                }  
                else if (typeclass == "Drink")
                {
                    Drink dish = new Drink(name, Convert.ToDouble(price),casttolist(ingredients),weight);
                    menu.menu.Add(number, dish);
                }
                else if (typeclass == "MainCourse")
                {
                    MainCourse dish = new MainCourse(name, Convert.ToDouble(price),casttolist(ingredients),weight);
                    menu.menu.Add(number, dish);
                }
                else if (typeclass == "Soup")
                {
                    Soup dish = new Soup(name, Convert.ToDouble(price),casttolist(ingredients),weight);
                    menu.menu.Add(number,dish);
                }
            sr.Close();
            }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        return menu;
        }
        public void Savemenu (Menu menu,String menuname)
        {
           Dictionary<int,Dish> menutosave = menu.GetMenu();
            var pth = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName+'/'+menuname;
            Console.WriteLine("\n"+pth);
            using var filestr = File.Create(pth);
            using var sw = new StreamWriter(filestr);
            foreach(KeyValuePair<int, Dish>  item in menutosave)
            {
                item.Key.ToString();
                sw.WriteLine(item.Key.ToString()+";"+item.Value.GetType().Name+";"+item.Value.DishToString());
            }
        }
        public static List<Ingredient> casttolist(String[] list)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach(String name in list)
            {
                Ingredient ingredient = new Ingredient(name);
                ingredients.Add(ingredient);
            }
            return ingredients;
        }
    }
}