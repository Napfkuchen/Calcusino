using Microsoft.EntityFrameworkCore;
using Calcusino.src.Backend.Models;

namespace Calcusino.Data
{
    public class CalcusinoDbContext : DbContext
    {
        public CalcusinoDbContext(DbContextOptions<CalcusinoDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}