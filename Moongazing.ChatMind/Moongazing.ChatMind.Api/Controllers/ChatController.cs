using Microsoft.AspNetCore.Mvc;

namespace Moongazing.ChatMind.Api.Controllers;

[ApiController]
[Route("api/chat")]
public class ChatController : ControllerBase
{
    private readonly IChatbotService _chatbotService;

    public ChatController(IChatbotService chatbotService)
    {
        _chatbotService = chatbotService;
    }

    [HttpPost("ask")]
    public async Task<IActionResult> AskQuestion([FromBody] ChatRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Question))
        {
            return BadRequest("Question cannot be empty.");
        }

        var answer = await _chatbotService.GetAnswerAsync(request.Question);
        return Ok(new { Question = request.Question, Answer = answer });
    }
}

public record ChatRequest(string Question);
