using Microsoft.EntityFrameworkCore;
using Spa.Api.Data;
using Spa.Api.Models;

namespace Spa.Api.Services;

public class BookingService(SpaDbContext db)
{
    public async Task<(bool Ok,string Message,Booking? Booking)> CreateAsync(Booking booking)
    {
        var conflict = await db.Bookings.AnyAsync(x =>
            x.ProfessionalId == booking.ProfessionalId &&
            x.Status != BookingStatus.Cancelled &&
            booking.Start < x.End && booking.End > x.Start);

        if (conflict) return (false, "El profesional ya tiene una cita en ese horario.", null);

        db.Bookings.Add(booking);
        await db.SaveChangesAsync();
        return (true, "Reserva creada.", booking);
    }
}
