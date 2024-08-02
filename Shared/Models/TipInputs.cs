using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DemoPWA4.Shared.Models
{
    public class TipInputs
    {
        [Required]
        //[TotalInputValidation]
        [Display(Name = "Before Tip $ Amount")]
        public decimal? preTipTotal { get; set; }

        [RequiredIf(nameof(tipByPercent), true)]
        [Display(Name = "Tip %")]
        public decimal? selectedTipPercent {  get; set; }

        [RequiredIf(nameof(tipByPercent), false)]
        [Display(Name = "Tip $ Amount")]
        public decimal? selectedTipDollarAmount { get; set; }

        [RequiredIf(nameof(tipByPostTaxTotal), false)]
        [Display(Name = "Tax $ Amount")]
        public decimal? taxAmount { get; set; }

        [Required]
        [Display(Name = "Tip by %")]
        public bool tipByPercent { get; set; } = true;

        [Required]
        [Display(Name = "Tip based on Tax plus Total")]
        public bool tipByPostTaxTotal { get; set; } = true;

        [Required]
        [Display(Name = "Round Final Total $ Amount")]
        public bool roundTotal { get; set; } = false;
    }

    public class RequiredIfAttribute : ValidationAttribute
    {
        private readonly string _propertyName;
        private readonly object? _isValue;

        public RequiredIfAttribute(string propertyName, object? isValue)
        {
            _propertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
            _isValue = isValue;
        }
        public override string FormatErrorMessage(string name)
        {
            //var errorMessage = $"{name} is required when {_propertyName} is {_isValue}";
            var errorMessage = $"{name} is required";
            return ErrorMessage ?? errorMessage;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            ArgumentNullException.ThrowIfNull(validationContext);
            var property = validationContext.ObjectType.GetProperty(_propertyName);

            if (property == null)
            {
                throw new NotSupportedException($"Can't find {_propertyName} on searched type: {validationContext.ObjectType.Name}");
            }

            var requiredIfTypeActualValue = property.GetValue(validationContext.ObjectInstance);

            if (requiredIfTypeActualValue == null && _isValue != null)
            {
                return ValidationResult.Success;
            }

            if (requiredIfTypeActualValue == null || requiredIfTypeActualValue.Equals(_isValue))
            {
                return value == null
                    ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName))
                    : ValidationResult.Success;
            }

            return ValidationResult.Success;
        }
    }

}
