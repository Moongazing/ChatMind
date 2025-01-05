using Microsoft.EntityFrameworkCore;
using Moongazing.ChatMind.Api.Entities;
using Moongazing.ChatMind.Api.Repositories;

public class ChatMessageRepository : Repository<ChatMessage>, IChatMessageRepository
{
    public ChatMessageRepository(DbContext context) : base(context) { }

    public async Task<List<ChatMessage>> GetRecentMessagesAsync(string userId, int limit = 10)
    {
        return await _dbSet
            .Where(m => m.UserId == userId)
            .OrderByDescending(m => m.CreatedAt)
            .Take(limit)
            .ToListAsync();
    }
}
