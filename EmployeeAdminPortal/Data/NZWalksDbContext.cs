using EmployeeAdminPortal.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("844f2e51-fa24-4e36-af7a-d74028643c46"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("fc441f42-a99a-4d8f-9a10-d5e1b1e2c026"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("bb44e9bb-907d-437c-95c3-f242ed19006f"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

        }
    }
}
