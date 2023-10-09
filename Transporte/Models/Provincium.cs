using System;
using System.Collections.Generic;

namespace Transporte.Models
{
    public partial class Provincium
    {
        public Provincium()
        {
            Clientes = new HashSet<Cliente>();
            Localidades = new HashSet<Localidade>();
        }

        public int IdProvincia { get; set; }
        public string? Provincia { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Localidade> Localidades { get; set; }
    }
}
