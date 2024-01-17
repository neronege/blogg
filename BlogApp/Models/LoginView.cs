using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class LoginView
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string? Email { get; set; }
        [Required]

        [StringLength(10, ErrorMessage = "{0} en az {2} karakter olmalıdır", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
