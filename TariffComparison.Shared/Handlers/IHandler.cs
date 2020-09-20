using TariffComparison.Shared.Commands;

namespace TariffComparison.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}