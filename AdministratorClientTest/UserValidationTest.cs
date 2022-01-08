using System;
using AdministratorClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdministratorClientTest
{
    [TestClass]
    public class UserValidationTest
    {
        private MainWindow mainWindow = new MainWindow();

        [TestMethod]
        public void IsValidUser_Empty_ReturnsError()
        {
            var result = mainWindow.IsValidUser("");
            Assert.IsNotNull(result);
            Assert.AreEqual("Nem lehet üres!", result);
        }

        [TestMethod]
        public void IsValidUser_Valid_ReturnsOk()
        {
            var result = mainWindow.IsValidUser("Teszt Elek");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsValidUser_InValid_ReturnsError()
        {
            var result = mainWindow.IsValidUser("Teszt-Elek");
            Assert.AreEqual("Nem használható speciális karakter!", result);
        }


    }
}
