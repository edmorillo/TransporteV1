using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
/*using Transporte.Validaciones;*/

namespace Transporte.Models
{
    public partial class Usuario
    {
        public int Id_Usuario { get; set; }
        public string? Username { get; set; }

        public string? Clave { get; set; }

        [NotMapped]
        public bool MantenerActivo { get; set; }
    }
}
