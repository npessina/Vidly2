using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Licencia de conducir")]
        public string DrivingLicense { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }
    }
}
