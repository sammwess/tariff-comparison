using Flunt.Notifications;
using Flunt.Validations;
using TariffComparison.Shared.Commands;

namespace TariffComparison.Domain.Commands {
    public class CreateComparisonCommand: Notifiable, ICommand {

        /// <summary>
        /// Consumption(kWh/year)
        /// </summary>
        public int Consumption { get; set; }

        /// <summary>
        /// Validating with flunt
        /// </summary>
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(Consumption, 0, "CreateComparisonCommand.Consumption", "Consumption needs to greater than zero")
            );
        }
    }
}