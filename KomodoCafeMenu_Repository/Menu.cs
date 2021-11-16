using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeMenu_Repository
{
    public class Menu
    {
        //POCO
        public string MealNumber { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }

        public Menu(){}

        public Menu (string mealNumber, string name, string description, string ingredients, decimal price)
        {
            MealNumber = mealNumber;
            Name = name;    
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
