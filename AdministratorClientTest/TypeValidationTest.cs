using System;
using AdministratorClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdministratorClientTest
{
    [TestClass]
    public class TypeValidationTest
    {
        private TaskWindow taskWindow = new TaskWindow(null);

        [TestMethod]
        public void IsValidType_Empty_ReturnsError()
        {
            var result = taskWindow.IsValidType("");
            Assert.IsNotNull(result);
            Assert.AreEqual("Nem lehet üres!", result);
        }

        [TestMethod]
        public void IsValidType_ValidType_ReturnsOk()
        {
            var result = taskWindow.IsValidType("Ford Mondeo");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsValidType_InvalidType_ReturnsError()
        {
            var result = taskWindow.IsValidType("Ford@Mondeo%");
            Assert.AreEqual("Nem használható speciális karakter!", result);
        }
    }
}
