using System;
using System.Collections.Generic;

namespace Transporte.Models
{
    public partial class FormasPago
    {
        public FormasPago()
        {
            Compras = new HashSet<Compra>();
        }

        public int IdFormaPago { get; set; }
        public string? FormaPago { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
