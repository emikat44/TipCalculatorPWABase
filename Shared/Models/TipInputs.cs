using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DemoPWA4.Shared.Models
{
    public class TipInputs
    {
        [Required]
        //[TotalInputValidation]
        [Display(Name = "Reciept Total")]
        public decimal? preTipTotal { get; set; }

        [Required]
        [Display(Name = "Tip Percent")]
        public decimal? selectedTipPercent {  get; set; }

        public decimal? calculatedTipAmount { get; set; }

        [Display(Name = "Tip Dollar Amount")]
        public decimal? selectedTipDollarAmount { get; set; }

        [Display(Name = "Total")]
        public decimal? postTipTotal { get; set; }
    }
}
