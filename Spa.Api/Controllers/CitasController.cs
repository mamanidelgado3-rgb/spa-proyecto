using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spa.Api.Data;
using Spa.Api.Models;

namespace Spa.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CitasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitas()
        {
            return await _context.Citas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Cita>> PostCita(Cita cita)
        {
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCitas), new { id = cita.Id }, cita);
        }
    }
}
