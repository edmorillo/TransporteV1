using System;
using System.Collections.Generic;

namespace Transporte.Models
{
    public partial class TdocumentoC
    {
        public TdocumentoC()
        {
            Choferes = new HashSet<Chofere>();
        }

        public int IdTdocuC { get; set; }
        public string? Detalle { get; set; }

        public virtual ICollection<Chofere> Choferes { get; set; }
    }
}
