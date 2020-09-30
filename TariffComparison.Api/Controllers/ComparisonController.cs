using Microsoft.AspNetCore.Mvc;
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