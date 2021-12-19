namespace SportsStore.Models
{
    public class CourseWorksListLine
    {
        public int CourseWorkLineId { get; set; }
        public CourseWork CourseWork { get; set; }
        public int Quantity { get; set; }
    }
}