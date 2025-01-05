using Microsoft.EntityFrameworkCore;

namespace Moongazing.ChatMind.Api.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext context;
    private readonly DbSet<T> dbSet;

    public Repository(DbContext context)
    {
        this.context = context;
        dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        dbSet.Update(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            dbSet.Remove(entity);
        }
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}