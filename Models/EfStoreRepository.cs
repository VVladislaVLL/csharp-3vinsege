using System.Linq;

namespace SportsStore.Models
{
    public class EfStoreRepository : IStoreRepository
    {
        private StoreDbContext context;

        public EfStoreRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<CourseWork> Works => context.CourseWorks;

        public void CreateCourseWork(CourseWork p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public void DeleteCourseWork(CourseWork p)
        {
            context.Remove(p);
            context.SaveChanges();
        }

        public void SaveCourseWork(CourseWork p)
        {
            context.SaveChanges();
        }
    }
}