using Flunt.Validations;

namespace TariffComparison.Domain.Entities
{
    public class CalculationModelBasicElectricityTariff : CalculationModel
    {
        public CalculationModelBasicElectricityTariff(decimal centkWh, decimal basicCostsPerMonth) : base(centkWh)
        {
            BasicCostsPerMonth = basicCostsPerMonth;

            // Validating with flunt
            AddNotifications(new Contract()
                .Requires()
                .IsTrue(BasicCostsPerMonth > 0, "CalculationModelBasicElectricityTariff.BasicCostsPerMonth", "BasicCostsPerMonth can't be less than or equals zero")
            );
        }

        /// <summary>
        /// Base costs per month €
        /// </summary>
        public decimal BasicCostsPerMonth { get; private set; }

        /// <summary>
        /// Calculate and return the Annual costs (€/year) 
        /// Example: base costs per month 5 € + consumption costs 22 cent/kWh
        /// </summary>
        /// <param name="consumption">Consumption (kWh/year)</param>
        /// <returns></returns>
        public override decimal GetAnnualCosts(int consumption)
        {
            return (BasicCostsPerMonth * 12) + consumption * CentkWh / 100;
        }
    }
}