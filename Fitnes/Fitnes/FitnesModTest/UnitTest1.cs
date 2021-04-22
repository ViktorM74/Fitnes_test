using Fitnes.BL.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FitnesModTest.Controller.Test
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void SetNowUserDataTest()
        {
            //Arrenge
            var userName = Guid.NewGuid().ToString();
            var birthdate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var controller = new UserController(userName);
            var gender = "man";

            //Act
            controller.SetNowUserData(gender, birthdate, weight, height);
            var controller2 = new UserController(userName);
            
            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthdate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
        }

        [TestMethod]
        public void SaveTest()
        {
            //Arrenge
            var userName = Guid.NewGuid().ToString();

            //Act
            var controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}
