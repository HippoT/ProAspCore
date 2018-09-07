using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        public ViewResult List() =>
            View(OrderRepository.Orders.Where(o => !o.Shipped));

        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int orderID)
        {
            Order order = OrderRepository.Orders.FirstOrDefault(o => o.OrderID == orderID);
            if(order != null)
            {
                order.Shipped = true;
                OrderRepository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }
    }
}