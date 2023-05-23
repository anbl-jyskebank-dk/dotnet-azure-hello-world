using Microsoft.AspNetCore.Mvc;
using Dapr;

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
    [HttpPost("dapr-hello-world")]
    public async Task<ActionResult> Dapr(string eventDto)
    {
        _logger.LogInformation(eventDto);
        return Ok();
    }

}
