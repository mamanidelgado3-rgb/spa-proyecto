using Microsoft.AspNetCore.Mvc;
using Spa.Api.Services;

namespace Spa.Api.Controllers;

[ApiController, Route("api/ai")]
public class AiController(AiAssistantService ai) : ControllerBase
{
    [HttpPost("chat")]
    public async Task<IActionResult> Chat([FromBody] ChatRequest request) => Ok(new { reply=await ai.ReplyAsync(request.Message) });
}
public record ChatRequest(string Message);
