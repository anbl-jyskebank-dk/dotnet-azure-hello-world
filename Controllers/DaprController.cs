using Microsoft.AspNetCore.Mvc;
using Dapr;
using Dapr.AspNetCore;

namespace dotnet_azure_hello_world.Controllers;

[ApiController]
[Route("/")]
public class DaprController : ControllerBase
{

    private readonly ILogger<DaprController> _logger;

    public DaprController(ILogger<DaprController> logger)
    {
        _logger = logger;
    }

    [Topic("cmd-pub-sub", "events", DeadLetterTopic = "failedMessages")]
    [HttpPost("hello-world")]
    public ActionResult Dapr(CloudEvent cloudEvent)
    {
        _logger.LogInformation("WeatherForecast: {cloudEvent}", cloudEvent);
        return Ok();
    }

}
