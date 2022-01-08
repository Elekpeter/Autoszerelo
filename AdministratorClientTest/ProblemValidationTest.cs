using System;
using AdministratorClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdministratorClientTest
{
    [TestClass]
    public class ProblemValidationTest
    {
        private MainWindow mainWindow = new MainWindow();

        [TestMethod]
        public void IsValidProblem_Empty_ReturnsError()
        {
            var result = mainWindow.IsValidProblem("");
            Assert.IsNotNull(result);
            Assert.AreEqual("Nem lehet üres!", result);
        }

        [TestMethod]
        public void IsValidProblem_Valid_ReturnsOK()
        {
            var result = mainWindow.IsValidProblem("A féklámpa nem világít");
            Assert.IsNull(result);
        }
    }
}
