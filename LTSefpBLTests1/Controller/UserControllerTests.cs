#region Libraries
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#endregion


namespace LTSefpBL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Guid - рандомный набор символов 128бит
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears ( - 18);
            var incometype = "multi";
            var earning = 500000;
            var controller = new UserController(userName);
            //Act
            controller.SetNewUserData(incometype, birthDate, earning);
            var control = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, control.CurrentUser.Name);
            Assert.AreEqual(birthDate, control.CurrentUser.BirthDate);
            Assert.AreEqual(incometype, control.CurrentUser.Type.ToString());
            Assert.AreEqual(earning, control.CurrentUser.Earning);
            
        }

        [TestMethod()]
        public void SaveTest()
        {
            // arrange - объявление
            var userName = Guid.NewGuid().ToString();
            // act - действие
            var controller = new UserController(userName);
            // assert - проверка теста
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}