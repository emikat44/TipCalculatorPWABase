using System.ComponentModel.DataAnnotations;

namespace DemoPWA4.Shared.Models
{
    class TotalInputValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((int)value>=0)
            {
                return null;
            }

            return new ValidationResult("The Total Amount cannot be a negative number",
                new[] { validationContext.MemberName });
        }
    }
}
