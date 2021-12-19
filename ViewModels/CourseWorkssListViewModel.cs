using System.Collections.Generic;
using SportsStore.Models;

namespace SportsStore.ViewModels
{
    public class CourseWorksListViewModel
    {
        public IEnumerable<CourseWork> Works { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentDepartment { get; set; }
    }
}