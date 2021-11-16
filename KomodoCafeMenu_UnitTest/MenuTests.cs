using KomodoCafeMenu_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeMenuRepo_UnitTest
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void SetMealNumber_ShouldSetCorrect()
        {
            Menu meal = new Menu();

            meal.MealNumber = "Combo #1";

            string expected = "Combo #1";
            string actual = meal.MealNumber;

            Assert.AreEqual(expected, actual);

        }
    }
}
