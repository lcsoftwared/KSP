using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSP.Models
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public string? ImgFoto { get; set; }
        [NotMapped] public IFormFile? Foto { get; set; }
        public string StrNombreCompleto { get; set; } = null!;
        public string StrPuesto { get; set; } = null!;
        public decimal MnySalario { get; set; }
        public bool BitEstatus { get; set; }
        public DateTime DatFechaContratacion { get; set; }
    }
}
