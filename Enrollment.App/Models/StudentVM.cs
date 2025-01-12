using System.ComponentModel.DataAnnotations;

namespace Enrollment.App.Models
{
    public class StudentVM
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Lastname { get; set; }
        [Required]
        [MaxLength(30)]
        public string Firstname { get; set; }

    }
}
