using TariffComparison.Shared.Commands;

namespace TariffComparison.Domain.Commands
{
    public class ProductCommandResult : ICommandResult
    {
        public ProductCommandResult()
        {

        }

        public ProductCommandResult(string tariffName, decimal annualCosts)
        {
            TariffName = tariffName;
            AnnualCosts = annualCosts;
        }

        /// <summary>
        /// Product's name
        /// </summary>
        public string TariffName { get; set; }

        /// <summary>
        /// Annual costs(€/year)
        /// </summary>
        public decimal AnnualCosts { get; set; }
    }
}