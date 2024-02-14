using System.ComponentModel.DataAnnotations;

namespace NikeStore.ViewModels.Home
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Please enter valid username!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter valid password!")]
        public string Password { get; set; }
    }
}