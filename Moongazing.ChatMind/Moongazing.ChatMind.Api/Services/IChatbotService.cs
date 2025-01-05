public interface IChatbotService
{
   
    Task<string> GetAnswerAsync(string question);
}
