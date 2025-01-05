using Moongazing.ChatMind.Api.Entities;
using Moongazing.ChatMind.Api.Repositories;

public interface IChatMessageRepository : IRepository<ChatMessage>
{
    Task<List<ChatMessage>> GetRecentMessagesAsync(string userId, int limit = 10);
}
