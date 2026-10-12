using System;
using System.ComponentModel.DataAnnotations;

namespace Spa.Api.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Required]
        public string ClienteNombre { get; set; } = string.Empty;

        [Required]
        public string ClienteTelefono { get; set; } = string.Empty;

        [Required]
        public string Servicio { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public DateTime FechaHora { get; set; }

        [Required]
        public string MetodoPago { get; set; } = string.Empty;

        public string CodigoComprobante { get; set; } = string.Empty;

        public string Estado { get; set; } = "Pendiente";

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
