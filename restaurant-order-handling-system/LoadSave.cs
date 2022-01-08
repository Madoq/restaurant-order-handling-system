using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_order_handling_system.Dishes
{
    internal class LoadSave
    {
        public static void load(string repoName)
        {
            try
            {
                //StreamReader sr = new StreamReader($"repos/{repoName}.txt");
                //string[] newDishes = sr.ReadToEnd().Split("\n\n");
                ////name, price, ingredients, weight
                //foreach(string dish in newDishes)
                //{
                    
                //}

                //int postNr = (posts.Count > 0) ? posts.Keys.Max() + 1 : 1;
                //foreach (string newPost in newPosts) posts.Add(postNr++, newPost);
                //sr.Close();

                //repoName = repo.txt
                //repo:
                //
                //content1
                //content2
                //...
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}