using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly Home _home;

        public AccountController(Home home)
        {
            _home = home;
        }

        public IActionResult Index()
        {
            ViewBag.SessionData = _home.SessionData;
            return View();
        }
    }
}
