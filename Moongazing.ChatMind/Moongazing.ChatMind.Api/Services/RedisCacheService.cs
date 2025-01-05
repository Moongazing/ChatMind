using StackExchange.Redis;

public class RedisCacheService : ICacheService
{
    private readonly IDatabase database;

    public RedisCacheService(IConnectionMultiplexer redisConnection)
    {
        database = redisConnection.GetDatabase();
    }

    public async Task<string?> GetAsync(string key)
    {
        return await database.StringGetAsync(key);
    }

    public async Task SetAsync(string key, string value)
    {
        await database.StringSetAsync(key, value, TimeSpan.FromHours(1));
    }
}
