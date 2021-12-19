using System.Linq;

namespace SportsStore.Models
{
    public interface IStoreRepository
    {
        IQueryable<CourseWork> Works { get; }

        void SaveCourseWork(CourseWork p);
        void CreateCourseWork(CourseWork p);
        void DeleteCourseWork(CourseWork p);
    }
}