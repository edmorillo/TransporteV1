using System;
using System.Collections.Generic;

namespace Transporte.Models
{
    public partial class LicenciaChofer
    {
        public int IdLicenciaChofer { get; set; }
        public int? IdChofer { get; set; }
        public int? IdTiposDocumentos { get; set; }
        public DateTime? FechaVencimiento { get; set; }

        public virtual Chofere? IdChoferNavigation { get; set; }
        public virtual TiposDocumento? IdTiposDocumentosNavigation { get; set; }
    }
}
