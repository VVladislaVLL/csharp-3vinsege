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
        private readonly Cart cart;

        public CartController(IStoreRepository repository, Cart cartService)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.cart = cartService ?? throw new ArgumentNullException(nameof(cartService));
        }

        [HttpGet]
        public IActionResult Index(string returnUrl)
        {
            return View(new CartViewModel
            {
                ReturnUrl = returnUrl ?? "/"
            });
        }

        [HttpPost]
        public IActionResult Index(long productId, string returnUrl)
        {
            Product product = repository
                .Products
                .FirstOrDefault(p => p.ProductId == productId);

            cart.AddItem(product, 1);

            return View(new CartViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public IActionResult Remove(long productId, string returnUrl)
        {
            cart.RemoveLine(cart.Lines.First(cl => cl.Product.ProductId == productId).Product);
            
            return View("Index", new CartViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl ?? "/"
            });
        }
    }
}