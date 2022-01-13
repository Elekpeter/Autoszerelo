using System;
using AdministratorClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdministratorClientTest
{
    [TestClass]
    public class LicensePlateValidationTest
    {
        private TaskWindow taskWindow = new TaskWindow(null);

        [TestMethod]
        public void IsValidLicensePlate_Empty_ReturnsError()
        {
            var result = taskWindow.IsValidLicensePlate("");
            Assert.IsNotNull(result);
            Assert.AreEqual("Nem lehet üres!", result);
        }

        [TestMethod]
        public void IsValidLicensePlate_Valid_ReturnsOK()
        {
            var result = taskWindow.IsValidLicensePlate("ABC-123");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsValidLicensePlate_InValid_ReturnsError()
        {
            var result = taskWindow.IsValidLicensePlate("AA BB 245");
            Assert.AreEqual("Rossz formátum! A helyes: XXX-000", result);
        }

        [TestMethod]
        public void IsValidLicensePlate_InValid_ReturnsError2()
        {
            var result = taskWindow.IsValidLicensePlate("ABC-1234");
            Assert.AreEqual("Rossz formátum! A helyes: XXX-000", result);
        }
    }
}

