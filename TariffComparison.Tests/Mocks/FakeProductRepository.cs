using System.Collections.Generic;
using TariffComparison.Domain.Entities;
using TariffComparison.Domain.Repositories;

namespace TariffComparison.Tests.Mocks
{
    public class FakeProductRepository : IProductRepository
    {
        public IList<Product> GetAll()
        {
            //  Calculation model: base costs per month 5 € + consumption costs 22 cent/kWh 
            //  Examples:
            //  • Consumption = 3500 kWh / year => Annual costs = 830 €/ year(5€ *12 months = 60 € base
            //    costs + 3500 kWh / year * 22 cent / kWh = 770 € consumption costs)
            //  • Consumption = 4500 kWh / year => Annual costs = 1050 €/ year(5€ *12 months = 60 € base
            //    costs + 4500 kWh / year * 22 cent / kWh = 990 € consumption costs)
            //  • Consumption = 6000 kWh / year => Annual costs = 1380 €/ year(5€ *12 months = 60 € base 
            //    costs + 6000 kWh / year * 22 cent / kWh = 1320 € consumption costs)
            var modelBasic = new CalculationModelBasicElectricityTariff(22, 5);
            var productA = new Product("Basic electricity tariff", modelBasic);


            //  Calculation model: 800 € for up to 4000 kWh / year and above 4000 kWh / year additionally 30 cent / kWh.
            //  Examples:
            //  • Consumption = 3500 kWh / year => Annual costs = 800 €/ year
            //  • Consumption = 4500 kWh / year => Annual costs = 950 €/ year(800€ +500 kWh * 30 cent / kWh
            //    = 150 € additional consumption costs)
            //  • Consumption = 6000 kWh / year => Annual costs = 1400 €/ year(800€ +2000 kWh * 30
            //    cent / kWh = 600 € additional consumption costs)
            var modelPackaged = new CalculationModelPackagedTariff(30, 800, 4000);
            var productB = new Product("Packaged tariff", modelPackaged);

            return new List<Product> { productA, productB };
        }

        /// <summary>
        /// Save new product not implemented here in mock
        /// </summary>
        /// <param name="product"></param>
        public void Save(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}