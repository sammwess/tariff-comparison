using Microsoft.AspNetCore.Mvc;
using ServiceStack.Api.Swagger;
using Swashbuckle.AspNetCore.Annotations;
using TariffComparison.Domain.Commands;
using TariffComparison.Domain.Handlers;

[Route("v1/comparison")]
public class ComparisonController : ControllerBase
{

    private readonly ComparisonHandler _handler;

    public ComparisonController(ComparisonHandler handler)
    {
        this._handler = handler;
    }

    /// <summary>
    /// Initializes the products in memory for testing
    /// </summary>
    /// <returns>The result of the operation</returns>
    [SwaggerOperation(Summary = "Initializes the products in memory for testing")]
    [Route("init")]
    [HttpPost]
    public ActionResult Init()
    {
        var basicCommand = new CreateBasicElectricityTariffProductCommand();
        basicCommand.Name = "Basic electricity tariff";
        basicCommand.CentkWh = 22;
        basicCommand.BasicCostsPerMonth = 5;
        var result = _handler.Handle(basicCommand);
        if (_handler.Invalid)
        {
            return BadRequest(result);
        }

        var packagedCommand = new CreatePackagedTariffProductCommand();
        packagedCommand.Name = "Packaged tariff";
        packagedCommand.CentkWh = 30;
        packagedCommand.BasicCostsPerYear = 800;
        packagedCommand.BasicConsumption = 4000;
        result = _handler.Handle(packagedCommand);
        if (_handler.Invalid)
        {
            return BadRequest(result);
        }

        return Ok();
    }


    /// <summary>
    ///  Compares the products based on their annual costs.
    /// </summary>
    /// <param name="consumption"></param>
    /// <returns>Retrieve the products sorted by costs in ascending order.</returns>
    [SwaggerOperation(Summary = "Compares the products based on their annual costs and retrieve them sorted by costs in ascending order.")]
    [HttpGet]
    [Route("{consumption:int}")]
    public ActionResult Get(int consumption)
    {

        // Creating the command
        var command = new CreateComparisonCommand();
        command.Consumption = consumption;

        // Creating the handler
        var result = _handler.Handle(command);

        // Handler validation
        if (_handler.Invalid)
        {
            // Error result
            return BadRequest(result);
        }

        //Success result
        return Ok(_handler.Handle(command));
    }
}