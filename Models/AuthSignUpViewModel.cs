using System.ComponentModel.DataAnnotations;

namespace MVCWeek9.Models
{
    public class AuthSignUpViewModel  // to exchange data from Authcontroller to Sign Up view
    {
        public string Email {get;set;}
        public string FullName {get;set;}

        public string PhoneNumber {get;set;}

        public string Password {get;set;}

        [Compare(nameof(Password))]
        public string PasswordConfirm {get;set;}
    }
}