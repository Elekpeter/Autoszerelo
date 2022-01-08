using System;
using AdministratorClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdministratorClientTest
{
    [TestClass]
    public class LicensePlateValidationTest
    {
        private MainWindow mainWindow = new MainWindow();

        [TestMethod]
        public void IsValidLicensePlate_Empty_ReturnsError()
        {
            var result = mainWindow.IsValidLicensePlate("");
            Assert.IsNotNull(result);
            Assert.AreEqual("Nem lehet üres!", result);
        }

        [TestMethod]
        public void IsValidLicensePlate_Valid_ReturnsOK()
        {
            var result = mainWindow.IsValidLicensePlate("ABC-123");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsValidLicensePlate_InValid_ReturnsError()
        {
            var result = mainWindow.IsValidLicensePlate("AA BB 245");
            Assert.AreEqual("Rossz formátum! A helyes: XXX-000", result);
        }

        [TestMethod]
        public void IsValidLicensePlate_InValid_ReturnsError2()
        {
            var result = mainWindow.IsValidLicensePlate("ABC-1234");
            Assert.AreEqual("Rossz formátum! A helyes: XXX-000", result);
        }
    }
}

