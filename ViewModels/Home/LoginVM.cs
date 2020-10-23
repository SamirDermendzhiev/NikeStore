using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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