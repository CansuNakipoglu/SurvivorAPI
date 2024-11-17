using Microsoft.EntityFrameworkCore;
using SurvivorAPI.Model;

namespace SurvivorAPI.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}