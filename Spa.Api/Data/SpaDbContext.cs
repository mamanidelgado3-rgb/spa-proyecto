using Microsoft.EntityFrameworkCore;
using Spa.Api.Models;

namespace Spa.Api.Data;

public class SpaDbContext(DbContextOptions<SpaDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<ServiceItem> Services => Set<ServiceItem>();
    public DbSet<Professional> Professionals => Set<Professional>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Payment> Payments => Set<Payment>();
}
