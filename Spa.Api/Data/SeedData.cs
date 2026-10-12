using Spa.Api.Models;

namespace Spa.Api.Data;

public static class SeedData
{
    public static void Run(SpaDbContext db)
    {
        if (db.Services.Any()) return;

        db.Services.AddRange(
            new ServiceItem { Name="Masaje relajante", DurationMinutes=60, Price=80 },
            new ServiceItem { Name="Masaje descontracturante", DurationMinutes=60, Price=100 },
            new ServiceItem { Name="Limpieza facial", DurationMinutes=50, Price=70 }
        );
        db.Professionals.AddRange(
            new Professional { Name="Profesional 1", Phone="" },
            new Professional { Name="Profesional 2", Phone="" }
        );
        db.SaveChanges();
    }
}
