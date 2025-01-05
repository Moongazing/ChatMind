using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Moongazing.ChatMind.Api.Hubs;

public class ChatHub : Hub
{
    private readonly IMediator mediator;

    public ChatHub(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async Task SendQuestion(string userId, string question)
    {
        var answer = await mediator.Send(new CreateChatMessageCommand(userId, question));
        await Clients.Caller.SendAsync("ReceiveAnswer", question, answer);
    }
}