using CheckMate.API.models;
using CheckMate.API.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CheckMate.API
{
    public class CheckMateDbContext : DbContext
    {
        public CheckMateDbContext(DbContextOptions<CheckMateDbContext> options) : base(options) {}

        public virtual DbSet<ActionItem> ActionItems { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ActionItemConfiguration());
        }
    }
}
