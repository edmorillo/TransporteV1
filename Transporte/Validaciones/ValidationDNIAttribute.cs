using FitLife.Helpers;
using System.ComponentModel.DataAnnotations;


namespace Transporte.Validaciones
{
    public class ValidationDNI : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not null)
            {
                return HelperValidation.CheckDNI((string)value);
            }
            else
            {
                return false;
            }
        }
    }
}
