using Microsoft.VisualStudio.TestTools.UnitTesting;
using TariffComparison.Domain.Entities;

namespace TariffComparison.Tests.Entities
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("")]
        [DataRow("ab")]
        public void ShouldReturnErrorWhenNameIsInvalid(string name)
        {
            var model = new CalculationModelBasicElectricityTariff(20, 5);
            var product = new Product(name, model);
            Assert.IsTrue(product.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("basic electricity tariff")]
        public void ShouldReturnSuccessWhenNameIsValid(string name)
        {
            var model = new CalculationModelBasicElectricityTariff(20, 5);
            var product = new Product(name, model);
            Assert.IsTrue(product.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCalculationModelIsNull()
        {
            var product = new Product("basic electricity tariff", null);
            Assert.IsTrue(product.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCalculationModelIsNotNull()
        {
            var model = new CalculationModelPackagedTariff(30, 800, 4000);
            var product = new Product("Packaged tariff", model);
            Assert.IsTrue(product.Valid);
        }
    }
}