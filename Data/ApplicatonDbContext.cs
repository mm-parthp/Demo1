using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Data
{
    public class ApplicatonDbContext : DbContext
    {
        public ApplicatonDbContext(DbContextOptions<ApplicatonDbContext> options) : base(options)
        {
        }
        
        public DbSet<register> registers { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
