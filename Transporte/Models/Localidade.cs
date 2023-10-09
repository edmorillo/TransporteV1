using System;
using System.Collections.Generic;

namespace Transporte.Models
{
    public partial class Localidade
    {
        public Localidade()
        {
            Clientes = new HashSet<Cliente>();
            Viajes = new HashSet<Viaje>();
        }

        public int IdLocalidad { get; set; }
        public int? IdProvincia { get; set; }
        public string? Localidad { get; set; }

        public virtual Provincium? IdProvinciaNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
