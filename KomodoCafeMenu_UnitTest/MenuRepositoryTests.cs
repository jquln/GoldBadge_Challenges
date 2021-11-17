using KomodoCafeMenu_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeMenu_UnitTest
{
    [TestClass]
    public class MenuRepositoryTests
    {
        private MenuRepository _repo;
        private Menu _meal;


        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _meal = new Menu("Combo #1", "name", "description", "ingredients", 0.00m);

            _repo.AddMealsToList(_meal);

        }
        


        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {

            // Arrange
            Menu meal = new Menu();
            meal.MealNumber = "Combo #1";
            MenuRepository repository = new MenuRepository();

            // Act
            repository.AddMealsToList(meal);
            Menu mealFromDirectory = repository.GetMealByNumber("Combo #1");

            //Assert
            Assert.IsNotNull(mealFromDirectory);

        }

        // Uppdate
        [TestMethod]
        public void UpdateExistingMenu_ShouldReturnTrue()
        {
            // Arrange
            // TestInitialize
            Menu newMeal = new Menu("Combo #2", "name", "description", "ingredients", 3.00m);

            // Act
            bool updateResult = _repo.UpdateExistingMenu("Combo #1", newMeal);

            // Assert
            Assert.IsTrue(updateResult);

        }

        [DataTestMethod]
        [DataRow("Combo #1", true)]
        [DataRow("Combo #2", false)]
        public void UpdateExistingMenu_ShouldMatchGivenBool(string originalNumber, bool shouldUpdate)
        {
            // Arrange
            // TestInitialize
            Menu newMeal = new Menu("Combo #2", "name", "description", "ingredients", 3.00m);

            // Act
            bool updateResult = _repo.UpdateExistingMenu(originalNumber, newMeal);

            // Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteMeal_ShouldReturnTrue()
        {
            // Arrange

            // Act
            bool deleteResult = _repo.RemoveMealFromList(_meal.MealNumber);

            // Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
