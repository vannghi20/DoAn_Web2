using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectWeb2.Interfaces;
using ProjectWeb2.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProjectWeb2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactLogic _contactLogic;
        public HomeController(ILogger<HomeController> logger, IContactLogic contactLogic)
        {
            _contactLogic = contactLogic;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View("Contact");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMess(ContacUs contac)
        {
            if (ModelState.IsValid)
            {
                var response = await _contactLogic.CreatNewMess(contac);
                if (response)
                {
                    ViewBag.ConfirmMsg = "Cảm ơn bạn đã phản hồi";
                }
                else
                {
                    ViewBag.ConfirmMsg = "Kiểm tra lại thông tin nhé!";
                }
            }

            return View("Contact");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
