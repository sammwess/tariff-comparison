using Microsoft.VisualStudio.TestTools.UnitTesting;
using TariffComparison.Domain.Entities;

namespace TariffComparison.Tests.Entities
{
    [TestClass]
    public class CalculationModelPackagedTariffTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void ShouldReturnErrorWhenBasicCostsPerYearIsInvalid(int basicCostsPerYear)
        {
            var basicCostsPerYearDec = (decimal)basicCostsPerYear;
            var model = new CalculationModelPackagedTariff(30, basicCostsPerYearDec, 4000);
            Assert.IsTrue(model.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(800)]
        public void ShouldReturnSuccessWhenBasicCostsPerYearIsValid(int basicCostsPerYear)
        {
            var basicCostsPerYearDec = (decimal)basicCostsPerYear;
            var model = new CalculationModelPackagedTariff(30, basicCostsPerYearDec, 4000);
            Assert.IsTrue(model.Valid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void ShouldReturnErrorWhenBasicConsumptionIsInvalid(int basicConsumption)
        {
            var model = new CalculationModelPackagedTariff(30, 800, basicConsumption);
            Assert.IsTrue(model.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(4000)]
        public void ShouldReturnSuccessWhenBasicConsumptionIsValid(int basicConsumption)
        {
            var model = new CalculationModelPackagedTariff(30, 800, basicConsumption);
            Assert.IsTrue(model.Valid);
        }
    }
}