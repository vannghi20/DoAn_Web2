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
        private readonly IProductLogic _foodItemLogic;
        private readonly IContactLogic _contactLogic;
        public HomeController(ILogger<HomeController> logger, IContactLogic contactLogic, IProductLogic foodItemLogic)
        {
            _foodItemLogic = foodItemLogic;
            _contactLogic = contactLogic;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            IndexModel model = new IndexModel();
            var respone = await _foodItemLogic.GetFoodNE();
            var gq = await _foodItemLogic.GetFoodGQ();
            model.ProductGQ = gq;
            model.ProductNE = respone;
            return View("Index", model);
        }
        public async Task<IActionResult> Product()
        {
            HomeModels homeModels = new HomeModels();

            var respone = await _foodItemLogic.GetAllFood();


            if (respone != null)
            {
                return View("Product", respone);
            }
            return null;
        }
        public async Task<IActionResult> ProductGQ()
        {
            HomeModels homeModels = new HomeModels();

            var respone = await _foodItemLogic.GetFoodGQ();


            if (respone != null)
            {
                return View("Product", respone);
            }
            return null;
        }
        public async Task<IActionResult> ProductNE()
        {
            HomeModels homeModels = new HomeModels();

            var respone = await _foodItemLogic.GetFoodNE();


            if (respone != null)
            {
                return View("Product", respone);
            }
            return null;
        }
        //ProductDetail
        public async Task<IActionResult> Detail(string id)
        {
            var response = await _foodItemLogic.GetFoodById(id);
            if (response != null)
            {
                return View("ProductDetail", response);
            }
            return null;
        }
        //Dich vu
        public IActionResult DichVu()
        {
            return View();
        }
        //Contact
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
