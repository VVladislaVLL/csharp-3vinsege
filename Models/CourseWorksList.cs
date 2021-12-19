using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public class CourseWorksList
    {
        public List<CourseWorksListLine> Lines { get; set; } = new List<CourseWorksListLine>();

        public virtual void AddItem(CourseWork courseWork, int quantity)
        {
            CourseWorksListLine listLine = Lines.FirstOrDefault(p => p.CourseWork.CourseWorkId == courseWork.CourseWorkId);

            if (listLine == null)
            {
                Lines.Add(new CourseWorksListLine
                {
                    CourseWork = courseWork,
                    Quantity = quantity
                });
            }
            else
            {
                listLine.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(CourseWork courseWork) =>
            Lines.RemoveAll(l => l.CourseWork.CourseWorkId == courseWork.CourseWorkId);

        public decimal ComputeTotalValue() =>
            Lines.Sum(e => e.CourseWork.Price * e.Quantity);

        public virtual void Clear() => Lines.Clear();
    }
}