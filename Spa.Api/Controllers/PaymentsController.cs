using Microsoft.AspNetCore.Mvc;
using Spa.Api.Services;

namespace Spa.Api.Controllers;

[ApiController, Route("api/payments")]
public class PaymentsController(PaymentService payments) : ControllerBase
{
    [HttpGet("instructions")]
    public IActionResult Instructions(decimal amount)=>Ok(payments.GetInstructions(amount));
}
