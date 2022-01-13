using System;
using AdministratorClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdministratorClientTest
{
    [TestClass]
    public class UserValidationTest
    {
        private TaskWindow taskWindow = new TaskWindow(null);

        [TestMethod]
        public void IsValidUser_Empty_ReturnsError()
        {
            var result = taskWindow.IsValidUser("");
            Assert.IsNotNull(result);
            Assert.AreEqual("Nem lehet üres!", result);
        }

        [TestMethod]
        public void IsValidUser_Valid_ReturnsOk()
        {
            var result = taskWindow.IsValidUser("Teszt Elek");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsValidUser_InValid_ReturnsError()
        {
            var result = taskWindow.IsValidUser("Teszt-Elek");
            Assert.AreEqual("Nem használható speciális karakter!", result);
        }


    }
}
