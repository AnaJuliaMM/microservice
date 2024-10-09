using Microsoft.EntityFrameworkCore;
using AuthMicroservice.src.Domain.Entities;

namespace AuthMicroservice.src.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }

}