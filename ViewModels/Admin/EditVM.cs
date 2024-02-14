using NikeStore.Entities;
using System.ComponentModel.DataAnnotations;

namespace NikeStore.ViewModels.Admin
{
    public class EditVM
    {
        [Required]
        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Enter comma separated numbers!")]
        public string Size { get; set; }
        public int Id { get; set; }
        public List<IFormFile> Image { get; set; }
        public string ImageName { get; set; }
        [Required]
        public float Price { get; set; }
        public string Name { get; set; }


        public List<Tag> Tags { get; set; }


        public EditVM()
        {
            Image = new List<IFormFile>();
        }
    }
}