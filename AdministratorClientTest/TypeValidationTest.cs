using System;
using AdministratorClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdministratorClientTest
{
    [TestClass]
    public class TypeValidationTest
    {
        private MainWindow mainWindow = new MainWindow();

        [TestMethod]
        public void IsValidType_Empty_ReturnsError()
        {
            var result = mainWindow.IsValidType("");
            Assert.IsNotNull(result);
            Assert.AreEqual("Nem lehet üres!", result);
        }

        [TestMethod]
        public void IsValidType_ValidType_ReturnsOk()
        {
            var result = mainWindow.IsValidType("Ford Mondeo");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsValidType_InvalidType_ReturnsError()
        {
            var result = mainWindow.IsValidType("Ford@Mondeo%");
            Assert.AreEqual("Nem használható speciális karakter!", result);
        }
    }
}
