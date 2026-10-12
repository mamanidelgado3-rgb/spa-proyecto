using Microsoft.Extensions.Options;

namespace Spa.Api.Services;

public class AiOptions { public bool Enabled {get;set;} public string ApiKey {get;set;}=""; }

public class AiAssistantService(IOptions<AiOptions> options)
{
    public Task<string> ReplyAsync(string message)
    {
        // Punto de integración: aquí se conectará el proveedor de IA elegido.
        if (message.Contains("reserva", StringComparison.OrdinalIgnoreCase))
            return Task.FromResult("Claro. Puedo ayudarte a reservar. Dime qué servicio deseas, la fecha y el horario aproximado.");
        return Task.FromResult("Hola. Soy el asistente del Spa. Puedo ayudarte con servicios, horarios y reservas.");
    }
}
