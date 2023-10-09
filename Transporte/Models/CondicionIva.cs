using System;
using System.Collections.Generic;

namespace Transporte.Models
{
    public partial class CondicionIva
    {
        public CondicionIva()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdCondicionIva { get; set; }
        public string? CondicionIva1 { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
