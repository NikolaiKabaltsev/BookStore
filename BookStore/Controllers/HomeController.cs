using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;

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
        public IActionResult Orders()
        {
            return View(db.Bookes.ToList());
        }
        public IActionResult ThxPage(Order order)
        {
            ViewBag.Order = order; //Передаем в "сумку" экземпляр недавнего заказа.
            return View();
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]

        public IActionResult Buy(Order order)
        {
            db.Orders.Add(order);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("ThxPage", order);
        }
    }
}
