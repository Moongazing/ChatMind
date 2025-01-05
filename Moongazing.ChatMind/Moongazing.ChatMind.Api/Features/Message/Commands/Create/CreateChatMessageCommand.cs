using MediatR;
using Moongazing.ChatMind.Api.Entities;

public record CreateChatMessageCommand(string UserId, string Question) : IRequest<string>;

public class CreateChatMessageCommandHandler : IRequestHandler<CreateChatMessageCommand, string>
{
    private readonly IChatbotService chatbotService;
    private readonly IChatMessageRepository repository;

    public CreateChatMessageCommandHandler(IChatbotService chatbotService, IChatMessageRepository repository)
    {
        this.chatbotService = chatbotService;
        this.repository = repository;
    }

    public async Task<string> Handle(CreateChatMessageCommand request, CancellationToken cancellationToken)
    {
        var answer = await chatbotService.GetAnswerAsync(request.Question);
        var chatMessage = new ChatMessage(request.UserId, request.Question, answer);

        await repository.SaveAsync(chatMessage);
        return answer!;
    }
}
