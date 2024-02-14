using System.ComponentModel.DataAnnotations;

namespace NikeStore.ViewModels.Home
{
    public class RegisterVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field is requiered!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This Field is requiered!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This Field is requiered!")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "This Field is requiered!")]
        [EmailAddress(ErrorMessage = "Enter valid Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field is requiered!")]
        [RegularExpression(@"^[a-zA-Z'\s]*$", ErrorMessage = "Enter valid name!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This Field is requiered!")]
        [RegularExpression(@"^[a-zA-Z'\s]*$", ErrorMessage = "Enter valid name!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This Field is requiered!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This Field is requiered!")]
        [RegularExpression(@"^\(?([0-9]{10})$", ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }

        public bool IsAdmin { get; set; }
    }
}