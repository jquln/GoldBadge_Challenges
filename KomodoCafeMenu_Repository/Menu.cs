using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeMenu_Repository
{
    public class Menu
    {
        private string v;

        //POCO
        public string MealNumber { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }

        public Menu(){}

        public Menu (string mealNumber, string name, string description, string ingredients, double price)
        {
            MealNumber = mealNumber;
            Name = name;    
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

        public Menu(string v)
        {
            this.v = v;
        }
    }
}
