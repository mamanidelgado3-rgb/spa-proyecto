using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spa.Api.Data;

namespace Spa.Api.Controllers;

[ApiController, Route("api/catalog")]
public class CatalogController(SpaDbContext db) : ControllerBase
{
    [HttpGet("services")] public async Task<IActionResult> Services()=>Ok(await db.Services.Where(x=>x.Active).ToListAsync());
    [HttpGet("professionals")] public async Task<IActionResult> Professionals()=>Ok(await db.Professionals.Where(x=>x.Active).ToListAsync());
}
