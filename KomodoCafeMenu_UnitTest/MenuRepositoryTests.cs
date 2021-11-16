using KomodoCafeMenu_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeMenu_UnitTest
{
    [TestClass]
    public class MenuRepositoryTests
    {
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            Menu meal = new Menu();
            meal.Name = "Combo #1";
            MenuRepository repository = new MenuRepository();

            repository.AddMealsToList(meal);
            Menu mealFromDirectory = repository.GetMealByNumber("Combo #1");

            Assert.IsNotNull(mealFromDirectory);

        }
    }
}
