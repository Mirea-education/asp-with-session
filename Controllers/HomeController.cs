using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Home _home;

        public HomeController(ILogger<HomeController> logger, Home home)
        {
            _logger = logger;
            _home = home;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("SessionKey", "Данные тут222222222222222");

            return View();
        }

        public IActionResult Privacy()
        {
            // Использование данных сессии
            _home.SessionData = HttpContext.Session.GetString("SessionKey") ?? "Сессия с данными пуста";

            return View(_home);
        }
    }
}
