using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Mvc;
using TariffComparison.Domain.Commands;
using TariffComparison.Domain.Handlers;
using TariffComparison.Tests.Mocks;

[Route("v1/comparison")]
public class ComparisonController : ControllerBase
{
    [HttpGet]
    [Route("{consumption:int}")]
    public ActionResult Get(int consumption) {
        
        // Creating the command
        var command = new CreateComparisonCommand();
        command.Consumption = consumption;
        
        // Creating the handler
        var handler = new ComparisonHandler(new FakeProductRepository());
        var result = handler.Handle(command);
        
        // Handler validation
        if (handler.Invalid) {
            // Error result
            return BadRequest(result);
        }

        //Success result
        return Ok(handler.Handle(command));
    }
}