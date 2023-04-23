using Gabriel_James.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabriel_James.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Basket basket;
        public OrderController(IOrderRepository repoService, Basket basketService)
        {
            repository = repoService;
            basket = basketService;
        }
        public ViewResult Checkout() => View(new Order());
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = basket.Items.ToArray();
                repository.SaveOrder(order);
                basket.Clear();
                return RedirectToPage("/Completed", new { orderId = order.OrderID });
            }
            else
            {
                return View();
            }
        }
    }
}
