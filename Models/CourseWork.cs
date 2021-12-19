using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class CourseWork
    {
        public long CourseWorkId { get; set; }

        [Required(ErrorMessage = "Please enter a topic of the course work")]
        public string TopicOfCourseWork { get; set; }

        [Required(ErrorMessage = "Please enter a mentor of the course work")]
        public string Mentor { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please specify a department")]
        public string Department { get; set; }
    }
}