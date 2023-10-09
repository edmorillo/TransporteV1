using System;
using System.Collections.Generic;

namespace Transporte.Models
{
    public partial class LicenciasUnidad
    {
        public int IdLicenciaUnidades { get; set; }
        public int? IdUnidad { get; set; }
        public int? IdTiposDocumentos { get; set; }
        public DateTime? FechaVencimiento { get; set; }

        public virtual TiposDocumento? IdTiposDocumentosNavigation { get; set; }
        public virtual Unidade? IdUnidadNavigation { get; set; }
    }
}
