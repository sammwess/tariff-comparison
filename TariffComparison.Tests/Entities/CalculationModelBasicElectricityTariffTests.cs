using Microsoft.VisualStudio.TestTools.UnitTesting;
using TariffComparison.Domain.Entities;

namespace TariffComparison.Tests.Entities
{
    [TestClass]
    public class CalculationModelBasicElectricityTariffTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void ShouldReturnErrorWhenCentKwhIsInvalid(int centKWh)
        {
            var centKWhDec = (decimal)centKWh;
            var model = new CalculationModelBasicElectricityTariff(centKWhDec, 5);
            Assert.IsTrue(model.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(20)]
        public void ShouldReturnSuccessWhenCentKwhIsValid(int centKWh)
        {
            var centKWhDec = (decimal)centKWh;
            var model = new CalculationModelBasicElectricityTariff(centKWhDec, 5);
            Assert.IsTrue(model.Valid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void ShouldReturnErrorWhenBasicCostsPerMonthIsInvalid(int basicCostsPerMonth)
        {
            var basicCostsPerMonthDec = (decimal)basicCostsPerMonth;
            var model = new CalculationModelBasicElectricityTariff(20, basicCostsPerMonthDec);
            Assert.IsTrue(model.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(5)]
        public void ShouldReturnSuccessWhenBasicCostsPerMonthIsValid(int basicCostsPerMonth)
        {
            var basicCostsPerMonthDec = (decimal)basicCostsPerMonth;
            var model = new CalculationModelBasicElectricityTariff(20, basicCostsPerMonthDec);
            Assert.IsTrue(model.Valid);
        }
    }
}