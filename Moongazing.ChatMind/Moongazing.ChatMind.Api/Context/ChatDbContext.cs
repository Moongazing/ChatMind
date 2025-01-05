using Microsoft.EntityFrameworkCore;
using Moongazing.ChatMind.Api.Entities;

namespace Moongazing.ChatMind.Api.Context
{
    public class ChatDbContext : DbContext
    {
        public DbSet<ChatMessage> ChatMessages { get; set; }

        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatMessage>().HasKey(m => m.Id);
            modelBuilder.Entity<ChatMessage>().Property(m => m.UserId).IsRequired();
            modelBuilder.Entity<ChatMessage>().Property(m => m.Question).IsRequired();
            modelBuilder.Entity<ChatMessage>().Property(m => m.Answer).IsRequired();
            modelBuilder.Entity<ChatMessage>().Property(m => m.CreatedAt);
        }
    }
}