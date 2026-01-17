using Microsoft.EntityFrameworkCore;
using StudyFlow.Models;

namespace StudyFlow.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Evaluation> Evaluations { get; set; }
public DbSet<User> Users { get; set; }
    }
}
