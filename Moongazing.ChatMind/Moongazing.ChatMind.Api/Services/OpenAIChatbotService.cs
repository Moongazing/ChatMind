using Betalgo.Ranul.OpenAI.Managers;
using Betalgo.Ranul.OpenAI.ObjectModels;
using Betalgo.Ranul.OpenAI.ObjectModels.RequestModels;
using static Betalgo.Ranul.OpenAI.ObjectModels.StaticValues;

namespace Moongazing.ChatMind.Api.Services;

public class OpenAIChatbotService : IChatbotService
{
    private readonly OpenAIService openAIService;
    private readonly ICacheService cacheService;

    public OpenAIChatbotService(OpenAIService openAIService, ICacheService cacheService)
    {
        this.openAIService = openAIService;
        this.cacheService = cacheService;
    }

    public async Task<string> GetAnswerAsync(string question)
    {
        if (string.IsNullOrWhiteSpace(question))
            throw new ArgumentException("Question cannot be empty.", nameof(question));

        var cachedAnswer = await cacheService.GetAsync(question);
        if (cachedAnswer != null)
        {
            return cachedAnswer;
        }

        var chatRequest = new ChatCompletionCreateRequest
        {
            Model = Models.Gpt_3_5_Turbo,
            Messages = new List<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage>
            {
                new Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage
                {
                    Role = ChatMessageRoles.User, 
                    Content = question
                }
            },
            MaxTokens = 100,
            Temperature = 0.7f
        };

        var chatResponse = await openAIService.ChatCompletion.CreateCompletion(chatRequest);

        if (chatResponse.Choices == null || !chatResponse.Choices.Any())
        {
            throw new Exception("No response received from OpenAI API.");
        }

        var answer = chatResponse.Choices.FirstOrDefault()?.Message.Content!.Trim() ?? "No response generated.";

        await cacheService.SetAsync(question, answer);

        return answer;
    }
}
