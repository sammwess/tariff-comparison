using Flunt.Validations;
using TariffComparison.Shared.Entities;

namespace TariffComparison.Domain.Entities
{
    public abstract class CalculationModel : Entity
    {

        public CalculationModel() { }

        protected CalculationModel(decimal centkWh)
        {
            CentkWh = centkWh;

            // Validating with flunt
            AddNotifications(new Contract()
                .Requires()
                .IsTrue(CentkWh > 0, "CalculationModel.CentkWh", "CentKWh can't be less than or equals zero")
            );
        }

        /// <summary>
        /// Consumption costs cent/kWh
        /// </summary>
        public decimal CentkWh { get; private set; }

        /// <summary>
        /// Calculate and return the Annual costs (€/year) 
        /// </summary>
        /// <param name="consumption">Consumption (kWh/year)</param>
        /// <returns></returns>
        public abstract decimal GetAnnualCosts(int consumption);
    }
}