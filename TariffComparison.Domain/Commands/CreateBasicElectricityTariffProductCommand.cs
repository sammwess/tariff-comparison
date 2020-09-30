using Flunt.Notifications;
using Flunt.Validations;
using TariffComparison.Shared.Commands;

namespace TariffComparison.Domain.Commands {
    public class CreateBasicElectricityTariffProductCommand : Notifiable, ICommand {

        /// <summary>
        /// Product's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Consumption costs cent/kWh
        /// </summary>
        public decimal CentkWh { get; set; }

        /// <summary>
        /// Base costs per month €
        /// </summary>
        public decimal BasicCostsPerMonth { get; set; }

        /// <summary>
        /// Validating with flunt
        /// </summary>
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Name, 3, "CreateBasicElectricityTariffProductCommand.Name", "Name needs to have at least three characters")
                .IsTrue(CentkWh > 0, "CreateBasicElectricityTariffProductCommand.CentkWh", "CentKWh can't be less than or equals zero")
                .IsTrue(BasicCostsPerMonth > 0, "CreateBasicElectricityTariffProductCommand.BasicCostsPerMonth", "BasicCostsPerMonth can't be less than or equals zero")
            );
        }
    }
}