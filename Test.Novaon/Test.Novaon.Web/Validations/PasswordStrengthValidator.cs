using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Test.Novaon.Web.Validations
{
    public class PasswordStrengthValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = "";

            try
            {
                password = Convert.ToString(value);
            }
            catch
            {
            }

            if (ValidatePassword(password, out string ErrorMessage))
            {
                return new ValidationResult(ErrorMessage);
            }
            else
            {
                return ValidationResult.Success;
            }
        }

        private bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                ErrorMessage = "Password should not be empty";
                return false;
                //throw new Exception("Password should not be empty");
            }

            Regex hasNumber = new Regex(@"[0-9]+");
            Regex hasUpperChar = new Regex(@"[A-Z]+");
            Regex hasMiniMaxChars = new Regex(@".{6,12}");
            Regex hasLowerChar = new Regex(@"[a-z]+");
            //Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one upper case letter";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = $"Password should not be less than 6 or greater than 12 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one numeric value";
                return false;
            }

            //else if (!hasSymbols.IsMatch(input))
            //{
            //    ErrorMessage = "Password should contain At least one special case characters";
            //    return false;
            //}
            else
            {
                return true;
            }
        }
    }
}
