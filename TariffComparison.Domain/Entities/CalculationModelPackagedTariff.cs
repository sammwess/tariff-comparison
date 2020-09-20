using Flunt.Validations;

namespace TariffComparison.Domain.Entities
{
    public class CalculationModelPackagedTariff : CalculationModel
    {
        public CalculationModelPackagedTariff(decimal centkWh, decimal basicCostsPerYear, int basicConsumption) : base(centkWh)
        {
            BasicCostsPerYear = basicCostsPerYear;
            BasicConsumption = basicConsumption;

            // Validating with flunt
            AddNotifications(new Contract()
                .Requires()
                .IsTrue(BasicCostsPerYear > 0, "CalculationModelPackagedTariff.BasicCostsPerYear", "BasicCostsPerYear can't be less than or equals zero")
                .IsTrue(BasicConsumption > 0, "CalculationModelPackagedTariff.BasicConsumption", "BasicConsumption can't be less than or equals zero")
            );
        }

        /// <summary>
        /// Base costs per year €
        /// </summary>
        public decimal BasicCostsPerYear { get; private set; }

        /// <summary>
        /// Basic consumption kWh/year
        /// </summary>
        public int BasicConsumption { get; private set; }

        /// <summary>
        /// Calculate and return the Annual costs (€/year)
        /// Example: 800 € for up to 4000 kWh/year and above 4000 kWh/year additionally 30 cent/kWh.
        /// </summary>
        /// <param name="consumption">Consumption (kWh/year)</param>
        /// <returns></returns>
        public override decimal GetAnnualCosts(int consumption)
        {
            if (consumption > BasicConsumption)
            {
                return BasicCostsPerYear + ((consumption - BasicConsumption) * CentkWh / 100);
            }
            
            return BasicCostsPerYear;
        }
    }
}