using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository OrderRepository;
        private Cart cart;

        public OrderController(IOrderRepository orderRepository, Cart cart)
        {
            OrderRepository = orderRepository;
            this.cart = cart;
        }

        public ViewResult CheckOut() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                OrderRepository.SaveOrder(order);
                return RedirectToAction("Completed");
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}