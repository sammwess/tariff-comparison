using Flunt.Validations;
using TariffComparison.Shared.Entities;

namespace TariffComparison.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string name, CalculationModel calculationModel)
        {
            Name = name;
            CalculationModel = calculationModel;

            // Validating with flunt
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Name, 3, "Product.Name", "Name needs to have at least three characters")
                .IsNotNull(CalculationModel, "Product.CalculationModel", "CalculationModel needs to be set")
            );
        }

        /// <summary>
        /// Product's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The calculation model to find the annual costs
        /// </summary>
        public CalculationModel CalculationModel { get; private set; }

        /// <summary>
        /// Calculate and return the Annual costs (€/year)
        /// </summary>
        /// <param name="consumption">Consumption (kWh/year)</param>
        /// <returns></returns>
        public decimal GetAnnualCosts(int consumption)
        {
            return CalculationModel.GetAnnualCosts(consumption);
        }
    }
}