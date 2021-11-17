using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeMenu_Repository
{
    public class MenuRepository
    {
        private List<Menu> _listOfMeal = new List<Menu>();

        //Create
        public void AddMealsToList(Menu meal)
        {
            _listOfMeal.Add(meal);
        }

        //R
        public List<Menu> GetMealList()
        {
            return _listOfMeal;
        }

        //U
        public bool UpdateExistingMenu(string originalNumber, Menu newMeal)
        {
            Menu oldMeal = GetMealByNumber(originalNumber);

            if (oldMeal != null)
            {
                oldMeal.MealNumber = newMeal.MealNumber;
                oldMeal.Name = newMeal.Name;
                oldMeal.Description = newMeal.Description;
                oldMeal.Ingredients = newMeal.Ingredients;
                oldMeal.Price = newMeal.Price;

                return true;
            }
            else
            {
                return false;
            }
        }


        //D
        public bool RemoveMealFromList(string number)
        {
            Menu meal = GetMealByNumber(number);

            if (meal == null)
            {
                return false;

            }

            int initialCount = _listOfMeal.Count;
            _listOfMeal.Remove(meal);

            if (initialCount > _listOfMeal.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        //Helper method
        public Menu GetMealByNumber(string number)
        {
            foreach (Menu meal in _listOfMeal)
            {
                if (meal.MealNumber.ToLower() == number.ToLower())
                {
                    return meal;
                }
            }

            return null;
        }

    }
}
