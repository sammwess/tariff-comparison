using Microsoft.VisualStudio.TestTools.UnitTesting;
using TariffComparison.Domain.Commands;

namespace TariffComparison.Tests.Commands
{
    [TestClass]
    public class CreateComparisonCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCommandIsInvalid()
        {
            var command = new CreateComparisonCommand();
            command.Validate();
            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCommandIsValid()
        {
            var command = new CreateComparisonCommand();
            command.Consumption = 3500;
            command.Validate();
            Assert.IsTrue(command.Valid);
        }
    }
}