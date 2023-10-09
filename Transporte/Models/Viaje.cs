using System;
using System.Collections.Generic;

namespace Transporte.Models
{
    public partial class Viaje
    {
        public int IdViajes { get; set; }
        public string? Viajes { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        public decimal? Tarifa { get; set; }
        public DateTime? FormaDeCobro { get; set; }
        public string? Escobrado { get; set; }
        public string? Detalle { get; set; }
        public int? Remito { get; set; }
        public int? Ncontenedor { get; set; }
        public string? EsFacturado { get; set; }
        public string? Entidad { get; set; }
        public int? Nfactura { get; set; }
        public int? IdChofer { get; set; }
        public int? IdLocalidad { get; set; }
        public int? IdCliente { get; set; }

        public virtual Chofere? IdChoferNavigation { get; set; }
        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Localidade? IdLocalidadNavigation { get; set; }
    }
}
