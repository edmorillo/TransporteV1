using System;
using System.Collections.Generic;

namespace Transporte.Models
{
    public partial class Unidade
    {
        public Unidade()
        {
            LicenciasUnidads = new HashSet<LicenciasUnidad>();
        }

        public int IdUnidad { get; set; }
        public string? Matricula { get; set; }
        public string? Chasis { get; set; }
        public string? Modelo { get; set; }
        public DateTime? Año { get; set; }
        public string? CapacidadCarga { get; set; }
        public int? IdTipoUnidad { get; set; }
        public int? IdNeumatico { get; set; }
        public int? Kilometros { get; set; }
        public DateTime? FechaMantenimiento { get; set; }
        public DateTime? FechaCompra { get; set; }
        public DateTime? VencimientoUnidad { get; set; }

        public virtual Neumatico? IdNeumaticoNavigation { get; set; }
        public virtual TipoUnidade? IdTipoUnidadNavigation { get; set; }
        public virtual ICollection<LicenciasUnidad> LicenciasUnidads { get; set; }
    }
}
