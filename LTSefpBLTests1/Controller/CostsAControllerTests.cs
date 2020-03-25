using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LTSefpBL.Model;
using System.Linq;

namespace LTSefpBL.Controller.Tests
{
    [TestClass()]
    public class CostsAControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var costName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var expenditureController = new CostsAController(userController.CurrentUser);
            var cost = new Costs(costName, rnd.Next(50, 450));

            //Act
            expenditureController.Add(cost, 1000);

            //Assert
            Assert.AreEqual(cost.Name, expenditureController.Cost.Cost.Last().Key.Name);
        }
    }
}