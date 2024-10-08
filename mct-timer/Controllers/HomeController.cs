using Microsoft.AspNetCore.Mvc;
using mct_timer.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace mct_timer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<ConfigMng> _config;


        public HomeController(ILogger<HomeController> logger, IOptions<ConfigMng> config)
        {
            _logger = logger;
            _config = config;

            if (AuthService.GetInstance == null)
                AuthService.Init(logger, config);
        }


        [JwtAuthentication]
        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Timer(string m = "15", string z = "America/New_York", string t = "coffee")
        {
            TempData["length"] = m;
            TempData["timezone"] = z;
            TempData["type"] = t;
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
