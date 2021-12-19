using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.ViewModels;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IStoreRepository repository;
        private readonly CourseWorksList _courseWorksList;

        public CartController(IStoreRepository repository, CourseWorksList courseWorksListService)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this._courseWorksList = courseWorksListService ?? throw new ArgumentNullException(nameof(courseWorksListService));
        }

        [HttpGet]
        public IActionResult Index(string returnUrl)
        {
            return View(new CourseWorksViewModel
            {
                ReturnUrl = returnUrl ?? "/"
            });
        }

        [HttpPost]
        public IActionResult Index(long courseWorkId, string returnUrl)
        {
            CourseWork courseWork = repository
                .Works
                .FirstOrDefault(p => p.CourseWorkId == courseWorkId);

            _courseWorksList.AddItem(courseWork, 1);

            return View(new CourseWorksViewModel
            {
                CourseWorksList = _courseWorksList,
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public IActionResult Remove(long courseWorkId, string returnUrl)
        {
            _courseWorksList.RemoveLine(_courseWorksList.Lines.First(cl => cl.CourseWork.CourseWorkId == courseWorkId).CourseWork);
            
            return View("Index", new CourseWorksViewModel
            {
                CourseWorksList = _courseWorksList,
                ReturnUrl = returnUrl ?? "/"
            });
        }
    }
}