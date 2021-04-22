using Fitnes.BL.Controller;
using Fitnes.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace FitnesModTest
{
    [TestClass]
    public class TestEatingController
    {
        [TestMethod]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            //var foodName = "Met";
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            //Act
            eatingController.Add(food, 100);

            //Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);

        }
    }
}
