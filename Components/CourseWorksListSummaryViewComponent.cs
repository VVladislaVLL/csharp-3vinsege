using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private CourseWorksList _courseWorksList;

        public CartSummaryViewComponent(CourseWorksList courseWorksListService)
        {
            _courseWorksList = courseWorksListService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_courseWorksList);
        }
    }
}