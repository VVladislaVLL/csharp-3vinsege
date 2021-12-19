using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private CourseWorksList _courseWorksList;

        public OrderController(IOrderRepository repoService, CourseWorksList courseWorksListService)
        {
            repository = repoService;
            _courseWorksList = courseWorksListService;
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (!_courseWorksList.Lines.Any())
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = _courseWorksList.Lines.ToArray();
                repository.SaveOrder(order);
                _courseWorksList.Clear();
                return View("Completed", order.OrderId);
            }

            return View();
        }
    }
}