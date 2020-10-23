using NikeStore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikeStore.ViewModels.Admin
{
    public class AddModelVM
    {
        [Required]
        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Enter comma separated numbers!")]
        public string Size { get; set; }
        
        public List<HttpPostedFileBase> Image { get; set; }
                
        [Required]
        public float Price { get; set; }
        public string Name { get; set; }
        public List<Tag> Tags { get; set; }
        public string AddTag { get; set; }
        public AddModelVM()
        {
            Image = new List<HttpPostedFileBase>();
        }
    }
}