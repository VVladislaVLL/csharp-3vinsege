using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever] public int OrderId { get; set; }
        [BindNever] public ICollection<CourseWorksListLine> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; }

        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a university name")]
        public string University { get; set; }

        [Required(ErrorMessage = "Please enter a course number")]
        public string Course { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a group number")]
        public string Group { get; set; }

        public bool GiftWrap { get; set; }

        [BindNever] public bool Shipped { get; set; }
    }
}