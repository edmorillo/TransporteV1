using System;
using System.Collections.Generic;

namespace Transporte.Models
{
    public partial class Compra
    {
        public int IdCompra { get; set; }
        public int? Cantidad { get; set; }
        public string? Detalle { get; set; }
        public decimal? Precio { get; set; }
        public int? IdFormaPago { get; set; }
        public DateTime? FechaCompra { get; set; }

        public virtual FormasPago? IdFormaPagoNavigation { get; set; }
    }
}
