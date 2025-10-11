using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WDP_Assessment_3.Models
{
    public class AIImage
    {
        public AIImage()
        {
            Prompt = "";
            ImageGenerator = "";
            Filename = "";
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Prompt { get; set; }

        [Required]
        [Display(Name = "Image Generator")]
        public string ImageGenerator { get; set; }

        [Display(Name = "Upload Date")]
        public DateTime UploadDate { get; set; } = DateTime.Now; // Default the current date and time

        public string Filename { get; set; }

        public int Like { get; set; }

        public bool canIncreaseLike { get; set; }

        [NotMapped]
        [Display(Name = "Image File")]
        public IFormFile? ImageFile { get; set; }
    }
}
