using CheckMate.API.models;
using Microsoft.EntityFrameworkCore;

namespace CheckMate.API
{
    public class CheckMateDbContext : DbContext
    {
        public CheckMateDbContext(DbContextOptions<CheckMateDbContext> options) : base(options)
        {
        }

        public virtual DbSet<ActionItem> ActionItems { get; set; }
        public virtual DbSet<ActionItemStatus> ActionItemStatuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
