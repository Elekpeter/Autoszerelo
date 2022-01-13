using System;
using AdministratorClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdministratorClientTest
{
    [TestClass]
    public class ProblemValidationTest
    {
        private TaskWindow taskWindow = new TaskWindow(null);

        [TestMethod]
        public void IsValidProblem_Empty_ReturnsError()
        {
            var result = taskWindow.IsValidProblem("");
            Assert.IsNotNull(result);
            Assert.AreEqual("Nem lehet üres!", result);
        }

        [TestMethod]
        public void IsValidProblem_Valid_ReturnsOK()
        {
            var result = taskWindow.IsValidProblem("A féklámpa nem világít");
            Assert.IsNull(result);
        }
    }
}
