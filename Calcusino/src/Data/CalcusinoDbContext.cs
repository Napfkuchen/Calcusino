using Microsoft.EntityFrameworkCore;
using Calcusino.Models;
using Calcusino.Controllers;

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