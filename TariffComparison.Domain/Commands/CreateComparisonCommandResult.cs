using System.Collections.Generic;
using TariffComparison.Shared.Commands;

namespace TariffComparison.Domain.Commands
{
    public class CreateComparisonCommandResult : CommandResult
    {
        public CreateComparisonCommandResult()
        {
            Products = new List<ProductCommandResult>();
        }

        public CreateComparisonCommandResult(bool success, string message) : base(success, message)
        {
            Products = new List<ProductCommandResult>();
        }

        /// <summary>
        /// List of all the products
        /// </summary>
        public IList<ProductCommandResult> Products { get; set; }
    }
}