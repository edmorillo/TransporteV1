using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Transporte.Validaciones;


namespace Transporte.Models
{
    public partial class Chofere
    {
        public Chofere()
        {
            LicenciaChofers = new HashSet<LicenciaChofer>();
            Viajes = new HashSet<Viaje>();
        }

        public int IdChofer { get; set; }
        //[Required(ErrorMessage = "El campo {0} es requerido")]
        [Remote(action: "VerificarExisteChoferes", controller: "Choferes")]
        public string Nombre { get; set; }
        /*[PrimeraLetraMayuscula]*/
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        [Display(Name = "Tipo Documento (*)")]
        public int IdTdocuC { get; set; }
        [Display(Name = "N° Documento (*)")]
        //[Required(ErrorMessage = "*El campo {0} es requerido")]
        //[StringLength(maximumLength: 8, MinimumLength = 8, ErrorMessage = "La logintud del campo {0} debe contener {1} digitos")]

        //[RegularExpression(@"S{8,8}$", ErrorMessage = "La contraseña debe tener entre 8 y 16 caracteres, al menos un dígito, al menos una minúscula y al menos una mayúscula.")]

        [RegularExpression("[0-9]{8,8}", ErrorMessage = "EL campo {0} debe tener 8 digitos")]
        public int Ndocumento { get; set; }
        //[Required(ErrorMessage = "*El campo {0} es requerido")]
        [EmailAddress(ErrorMessage ="El campo debe ser un correo electrónico válido")]
        public string Email { get; set; }
        public string Matricula { get; set; }
        
        public string Celular { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }
        //[Required(ErrorMessage = "*El campo {0} es requerido")]
        //[StringLength(maximumLength:11,MinimumLength =11, ErrorMessage = "La logintud del campo {0} debe contener {1} digitos")]
        [Display(Name = "Cuil (*)")]
        
        [RegularExpression("[0-9]{11,11}", ErrorMessage = "EL campo solo debe contener números y 11 digitos")]


        public string Cuil { get; set; }



        
        [Display(Name = "Fecha Alta")]
        [DataType(DataType.Date)]
        public DateTime? FechaAlta { get; set; }

        
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Baja")]
        public DateTime? FechaBaja { get; set; }
        [Display(Name = "Tipo Documento")]
        public virtual TdocumentoC IdTdocuCNavigation { get; set; }
        public virtual ICollection<LicenciaChofer> LicenciaChofers { get; set; }
        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
