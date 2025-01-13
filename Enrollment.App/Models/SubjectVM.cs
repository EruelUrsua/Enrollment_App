using System.ComponentModel.DataAnnotations;

namespace Enrollment.App.Models
{
    public class SubjectVM
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Course Code")]
        [MinLength(7)]
        [MaxLength(7)]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Course Description")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Description { get; set; }   
        
        public Decimal Units { get; set; }


    }
}
