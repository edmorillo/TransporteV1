using System;
using System.Collections.Generic;

namespace Transporte.Models
{
    public partial class TipoMarcasUnidade
    {
        public TipoMarcasUnidade()
        {
            TipoUnidades = new HashSet<TipoUnidade>();
        }

        public int IdTipoMarcaUnidad { get; set; }
        public string? TipoMarcaUnidad { get; set; }

        public virtual ICollection<TipoUnidade> TipoUnidades { get; set; }
    }
}
