using BTMS.BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BusDbContext db;
        public HomeController(BusDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            ViewBag.FromList = db.BusRoutes.Select(r=> r.From).Distinct().ToList();
            return View();
        }
    }
}
