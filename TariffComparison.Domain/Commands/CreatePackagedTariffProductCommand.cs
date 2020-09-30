using Flunt.Notifications;
using Flunt.Validations;
using TariffComparison.Shared.Commands;

namespace TariffComparison.Domain.Commands
{
    public class CreatePackagedTariffProductCommand : Notifiable, ICommand
    {

        /// <summary>
        /// Product's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Consumption costs cent/kWh
        /// </summary>
        public decimal CentkWh { get; set; }

        /// <summary>
        /// Base costs per year €
        /// </summary>
        public decimal BasicCostsPerYear { get; set; }

        /// <summary>
        /// Basic consumption kWh/year
        /// </summary>
        public int BasicConsumption { get; set; }


        /// <summary>
        /// Validating with flunt
        /// </summary>
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Name, 3, "CreatePackagedTariffProductCommand.Name", "Name needs to have at least three characters")
                .IsTrue(CentkWh > 0, "CreatePackagedTariffProductCommand.CentkWh", "CentKWh can't be less than or equals zero")
                .IsTrue(BasicCostsPerYear > 0, "CreatePackagedTariffProductCommand.BasicCostsPerYear", "BasicCostsPerYear can't be less than or equals zero")
                .IsTrue(BasicConsumption > 0, "CreatePackagedTariffProductCommand.BasicConsumption", "BasicConsumption can't be less than or equals zero")
            );
        }
    }
}