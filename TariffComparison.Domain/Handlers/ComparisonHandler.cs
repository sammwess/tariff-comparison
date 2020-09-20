using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using TariffComparison.Domain.Commands;
using TariffComparison.Domain.Entities;
using TariffComparison.Domain.Repositories;
using TariffComparison.Shared.Commands;
using TariffComparison.Shared.Handlers;

namespace TariffComparison.Domain.Handlers
{
    public class ComparisonHandler : Notifiable, IHandler<CreateComparisonCommand>
    {
        private readonly IProductRepository _repository;

        public ComparisonHandler(IProductRepository repository)
        {
            _repository = repository;

            // Validating with flunt
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(_repository, "ComparisonHandler.repository", "Repository needs to be set")
            );
        }

        /// <summary>
        /// Handle the comparison command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Handle(CreateComparisonCommand command)
        {
            if (Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "An error occurred, It was not possible to create the comparison.");
            }

            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Please inform consumption");
            }

            IList<Product> products;

            try
            {
                products = _repository.GetAll();
            }
            catch (System.Exception)
            {
                return new CommandResult(false, "An error occurred, it was not possible to get the products.");
            }

            var result = new CreateComparisonCommandResult();
            foreach (var product in products)
            {
                var annualCosts = product.GetAnnualCosts(command.Consumption);
                var productResult = new ProductCommandResult(product.Name, annualCosts);
                result.Products.Add(productResult);

                AddNotifications(product);
            }

            if (Invalid)
            {
                return new CommandResult(false, "It was not possible to create the comparison.");
            }

            result.Products = result.Products.OrderBy(p => p.AnnualCosts).ToArray();
            result.Success = true;
            return result;
        }
    }
}