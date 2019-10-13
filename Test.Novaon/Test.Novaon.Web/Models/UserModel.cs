using System.ComponentModel.DataAnnotations;
using Test.Novaon.Web.Validations;

namespace Test.Novaon.Web.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [EmailAddress(ErrorMessage = "The {0} is not format your-email@domain.com.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [PasswordStrengthValidator]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Compare("Password", ErrorMessage = "The password confirm not match!")]
        public string ConfirmPassword { get; set; }
    }

    public class UserSignInModel
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [EmailAddress(ErrorMessage = "The {0} is not format your-email@domain.com.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [PasswordStrengthValidator]
        public string Password { get; set; }
    }
}
