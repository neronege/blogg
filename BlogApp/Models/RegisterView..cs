using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class RegisterView
    {

        //public Guid UserId { get; set; }
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string? UserName { get; set; }
        [Required]
        [Display(Name = "Ad Soyad")]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string? Email { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "{0} en az {2} karakter olmalıdır", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Parola uyuşmuyor")]
        [Display(Name = "Password Tekrar"),]
        public string? Password2 { get; set; }
    }
}
