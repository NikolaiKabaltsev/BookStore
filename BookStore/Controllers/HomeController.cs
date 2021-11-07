using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Authorization;   


namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        BkContext db;
        public HomeController(BkContext context)
        {
            db = context;

        }
        public IActionResult Index()
        {
            return View(db.Bookes.ToList());
        }
        [Authorize]
        public IActionResult ListOrder()
        {
            ViewBag.Order = db.Orders.ToList();
            return View(db.Bookes.ToList());
        }

        public IActionResult ThxPage()
        {
            return View();
        }
        [Authorize]
        public IActionResult Buy(int id)
        {
            foreach (var product in db.Bookes.ToList())
            {
                if (product.User == User.Identity.Name && product.Id == id) return RedirectToAction("Index");
                if (product.Quantity == 0 && product.Id == id) return RedirectToAction("Index");
            }
            int f = 0;
            foreach (var Order in db.Orders.ToList())
            {
                if (Order.BookId == id)
                {
                    Order.Quantity = ++Order.Quantity;
                    db.Orders.Update(Order);
                    f = 1;
                }
            }
            if (f == 0)
            {
                Order order = new Order();
                order.BookId = id;
                order.UserId = User.Identity.Name;
                order.Quantity = 1;
                db.Orders.Add(order);
            }
            foreach (var product in db.Bookes.ToList())
            {
                if (product.Id == id) product.Quantity = --product.Quantity;
                db.Bookes.Update(product);
            }
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Сheckout(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Сheckout(Order order)
        {
            db.Orders.Add(order);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("DeleteOrders");
        }

        [Authorize]
        public IActionResult AddQuantity(int id)
        {
            foreach (var product in db.Bookes.ToList())
            {
                if (product.Id == id && product.Quantity == 0) return RedirectToAction("Orders");
                if (product.Id == id) product.Quantity = --product.Quantity;
                db.Bookes.Update(product);
            }
            foreach (var Order in db.Orders.ToList())
            {
                if (Order.BookId == id) Order.Quantity = ++Order.Quantity;
                db.Orders.Update(Order);
            }
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("ListOrder");
        }

        [Authorize]
        public IActionResult RemoveQuantity(int id)
        {
            foreach (var Order in db.Orders.ToList())
            {
                if (Order.BookId == id) Order.Quantity = --Order.Quantity;
                db.Orders.Update(Order);
                if (Order.BookId == id && Order.Quantity == 0) db.Orders.Remove(Order);
            }
            foreach (var product in db.Bookes.ToList())
            {
                if (product.Id == id) product.Quantity = ++product.Quantity;
                db.Bookes.Update(product);
            }
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("ListOrder");
        }
        [Authorize]
        public IActionResult DeleteOrder(int? id)
        {
            foreach (var order in db.Orders.ToList())
            {
                if (order.BookId == id)
                {
                    foreach (var product in db.Bookes.ToList())
                    {
                        if (product.Id == id) product.Quantity += order.Quantity;
                        db.Bookes.Update(product);
                    }
                    db.Orders.Remove(order);
                }
            }
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("ListOrder");
        }
        [Authorize]
        public IActionResult DeleteOrders(int? id)
        {
            foreach (var order in db.Orders.ToList())
            {
                if (order.UserId == User.Identity.Name) db.Orders.Remove(order);
            }
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("ThxPage");
        }

    }
}
