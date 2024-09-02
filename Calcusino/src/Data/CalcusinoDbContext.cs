using Microsoft.EntityFrameworkCore;
using Calcusino.Models;

namespace Calcusino.Data
{
    public class CalcusinoDbContext : DbContext
    {
        public CalcusinoDbContext(DbContextOptions<CalcusinoDbContext> options)
            : base(options)
        {
        }

        // Hinzufügen von DbSets
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}