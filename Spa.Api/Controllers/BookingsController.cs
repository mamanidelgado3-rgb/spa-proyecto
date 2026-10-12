using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spa.Api.Data;
using Spa.Api.Models;
using Spa.Api.Services;

namespace Spa.Api.Controllers;

[ApiController, Route("api/bookings")]
public class BookingsController(SpaDbContext db, BookingService bookingService, WhatsAppService whatsapp) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await db.Bookings.Include(x=>x.Client).Include(x=>x.Service).Include(x=>x.Professional).OrderBy(x=>x.Start).ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Booking booking)
    {
        var result=await bookingService.CreateAsync(booking);
        if(!result.Ok) return Conflict(new {message=result.Message});

        var b=result.Booking!;
        await whatsapp.SendBookingAsync(
            $"NUEVA RESERVA - SPA\\nCliente: {b.Client?.Name ?? "Cliente"}\\nServicio: {b.Service?.Name ?? "Servicio"}\\nFecha: {b.Start:dd/MM/yyyy}\\nHora: {b.Start:HH:mm}\\nEstado: Pendiente de pago");

        return Ok(b);
    }
}
