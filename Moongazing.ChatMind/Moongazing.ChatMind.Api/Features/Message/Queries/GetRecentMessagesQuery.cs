using MediatR;

public record GetRecentMessagesQuery(string UserId) : IRequest<List<ChatMessageDto>>;

public class GetRecentMessagesQueryHandler : IRequestHandler<GetRecentMessagesQuery, List<ChatMessageDto>>
{
    private readonly IChatMessageRepository _repository;

    public GetRecentMessagesQueryHandler(IChatMessageRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ChatMessageDto>> Handle(GetRecentMessagesQuery request, CancellationToken cancellationToken)
    {
        var messages = await _repository.GetRecentMessagesAsync(request.UserId);
        return messages.Select(m => new ChatMessageDto(m.Id, m.Question, m.Answer, m.CreatedAt)).ToList();
    }
}

public record ChatMessageDto(Guid Id, string Question, string Answer, DateTime CreatedAt);
