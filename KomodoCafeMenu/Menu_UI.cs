using KomodoCafeMenu_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeMenu
{
    class Menu_UI
    {
        private MenuRepository _mealRepo = new MenuRepository();

        public void Run()
        {
            SeedMenuList();
            Menu();
        }
        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {

                Console.WriteLine("Select a menu option:\n" +
                   "1. Create new MealNumber\n" +
                   "2. View All Meal\n" +
                   "3. View Meal By Number\n" +
                    "4. Update Existing Meal\n" +
                    "5. Delete Existing Meal\n" +
                    "6. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //create mealNumber
                        CreateNewMealNumber();
                        break;
                    case "2":
                        //view all meal
                        ShowAllMeal();
                        break;
                    case "3":
                        //view meal by number
                        ShowMealByNumber();
                        break;
                    case "4":
                        //update existing meal
                        UpdateExistingMeal();
                        break;
                    case "5":
                        //delete existing meal
                        DeleteExistingMeal();
                        break;
                    case "6":
                        //exit
                        (continueToRun) = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid number.");
                        break;
                }

                Console.WriteLine("Press Enter to proceed...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private void CreateNewMealNumber()
        {
            Menu newMeal = new Menu();

            // Title
            Console.WriteLine("Enter the new meal number for the meal:");
            newMeal.MealNumber = Console.ReadLine();

            //Name
            Console.WriteLine("Enter a name for the meal:");
            newMeal.Name = Console.ReadLine();

            //Description
            Console.WriteLine("Enter a description for the meal:");
            newMeal.Description = Console.ReadLine();

            //Ingredients
            bool HasAllIngredients = false;
            List<string> listIngredients = new List<string>();
            while (!HasAllIngredients)
            {
                Console.WriteLine("Enter an ingredient for the meal:");
                var userInput = Console.ReadLine();
                listIngredients.Add(userInput);
                Console.WriteLine("Add more ingredients? yes/no");
                var userInputYesOrNo = Console.ReadLine();
                if (userInputYesOrNo == "Yes".ToLower())
                {
                    HasAllIngredients = false;
                }
                else
                {
                    HasAllIngredients = true;
                }

            }
            //Price
            Console.WriteLine("Enter a price for the meal:");
            string priceAsString = Console.ReadLine();
            newMeal.Price = double.Parse(Console.ReadLine());

            _mealRepo.AddMealsToList(newMeal);

        }

        private void ShowAllMeal()
        {
            Console.Clear();

            List<Menu> listOfMeal = _mealRepo.GetMealList();
            foreach (Menu meal in listOfMeal)
            {
                Console.WriteLine($"Meal Number: {meal.MealNumber}\n" +
                   $"Name: {meal.Name}\n");
            }
        }
        private void ShowMealByNumber()
        {
            Console.Clear();

            Console.WriteLine("Enter the meal number of the meal you'd like to see:");
            string number = Console.ReadLine();

            Menu meal = _mealRepo.GetMealByNumber(number);

            if (meal != null)
            {
                Console.WriteLine($"Meal Number: {meal.MealNumber}\n" +
                  $"Name: {meal.Name}\n" +
                  $"Description: {meal.Description}\n" +
                  $"Ingredients: {meal.Ingredients}\n" +
                  $"Price: {meal.Price}\n");
            }
            else
            {
                Console.WriteLine("No meal by that number...");
            }

        }
        private void UpdateExistingMeal()
        {
            ShowAllMeal();

            Console.WriteLine("Enter the number of the meal you would like to update:");
            string oldMeal = Console.ReadLine();

            Menu newMeal = new Menu();

            // Title
            Console.WriteLine("Enter the new meal number for the meal:");
            newMeal.MealNumber = Console.ReadLine();

            //Name
            Console.WriteLine("Enter a name for the meal:");
            newMeal.Name = Console.ReadLine();

            //Description
            Console.WriteLine("Enter a description for the meal:");
            newMeal.Description = Console.ReadLine();

            //Ingredients
            bool HasAllIngredients = false;
            List<string> listIngredients = new List<string>();
            while (!HasAllIngredients)
            {
                Console.WriteLine("Enter an ingredient for the meal:");
                var userInput = Console.ReadLine();
                listIngredients.Add(userInput);
                Console.WriteLine("Add more ingredients? yes/no");
                var userInputYesOrNo = Console.ReadLine();
                if (userInputYesOrNo == "Yes".ToLower())
                {
                    HasAllIngredients = false;
                }
                else
                {
                    HasAllIngredients = true;
                }

            }
            //Price
            Console.WriteLine("Enter a price for the meal:");
            string priceAsString = Console.ReadLine();
            newMeal.Price = double.Parse(Console.ReadLine());

            bool wasUpdated = _mealRepo.UpdateExistingMenu(oldMeal, newMeal);
            if (wasUpdated)
            {
                Console.WriteLine("Meal updated successfully!");
            }
            else
            {
                Console.WriteLine("Meal updated failed...");
            }

        }
        private void DeleteExistingMeal()
        {
            ShowAllMeal();

            Console.WriteLine("\nEnter the number of meal you would like to remove:");

            string userInput = Console.ReadLine();

            bool wasDeleted = _mealRepo.RemoveMealFromList(userInput);
            if (wasDeleted)
            {
                Console.WriteLine("The meal was deleted successfully!");
            }
            else
            {
                Console.WriteLine("The meal could not be deleted...");
            }





        }


        private void SeedMenuList()
        {
            Menu mealNumber1 = new Menu("Combo #1", "meal name", "meal description", "meal ingredients", 3.00);
            Menu mealNumber2 = new Menu("Combo #2", "meal name2", "meal description2", "meal ingredients2", 4.00);
            Menu mealNumber3 = new Menu("Combo #3", "meal name3", "meal description3", "meal ingredients3", 6.00);

            _mealRepo.AddMealsToList(mealNumber1);
            _mealRepo.AddMealsToList(mealNumber2);
            _mealRepo.AddMealsToList(mealNumber3);
        }
    }
}
