namespace Moongazing.ChatMind.Api.Entities;

public class ChatMessage
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string UserId { get; private set; }
    public string Question { get; private set; }
    public string Answer { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public ChatMessage(string userId, string question, string answer)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        Question = question ?? throw new ArgumentNullException(nameof(question));
        Answer = answer ?? throw new ArgumentNullException(nameof(answer));
    }
}