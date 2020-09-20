using Microsoft.VisualStudio.TestTools.UnitTesting;
using TariffComparison.Domain.Commands;
using TariffComparison.Domain.Entities;
using TariffComparison.Domain.Handlers;
using TariffComparison.Tests.Mocks;

namespace TariffComparison.Tests.Handlers
{
    [TestClass]
    public class ComparisonHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenIsInvalid()
        {
            // I'm not informing the consumption for the command, neither the repository for the handler.
            var command = new CreateComparisonCommand();
            var handler = new ComparisonHandler(null);
            var result = handler.Handle(command);
            Assert.IsTrue(handler.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenIsValid()
        {
            // Valid comparison using the fake repository
            var command = new CreateComparisonCommand();
            command.Consumption = 3500;
            var handler = new ComparisonHandler(new FakeProductRepository());
            var result = handler.Handle(command);
            Assert.IsTrue(handler.Valid);
        }
    }
}