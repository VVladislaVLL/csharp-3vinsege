using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;
using SportsStore.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 4;

        public HomeController(IStoreRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index(string category, int productPage = 1)
            => View(new CourseWorksListViewModel
            {
                Works = repository.Works
                    .Where(p => category == null || p.Department == category)
                    .OrderBy(p => p.CourseWorkId)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null
                        ? repository.Works.Count()
                        : repository.Works.Count(e => e.Department == category)
                },
                CurrentDepartment = category
            });
    }
}