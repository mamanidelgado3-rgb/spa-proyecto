using Microsoft.EntityFrameworkCore;
using Spa.Api.Models;

namespace Spa.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cita> Citas { get; set; } = null!;
    }
}
