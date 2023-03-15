using System;
using System.Collections.Generic;

namespace KSP.Models
{
    public partial class Beneficiario
    {
        public int IdBeneficiario { get; set; }
        public int IdEmpleado { get; set; }
        public string StrNombreCompleto { get; set; } = null!;
        public int IdParentesco { get; set; }
        public DateTime DtFechaNacimiento { get; set; }
        public int? IdSexo { get; set; }
    }


}
