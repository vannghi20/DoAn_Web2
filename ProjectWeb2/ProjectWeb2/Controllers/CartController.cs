using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using ProjectWeb2.Interfaces;
using ProjectWeb2.Models;
using System.Threading.Tasks;

namespace ProjectWeb2.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly IProductLogic _foodItemLogic;
        private readonly ICartItemLogic _cartItemLogic;
        public List<CartItem> items;
        public CartController(ILogger<CartController> logger, IProductLogic foodItemLogic, ICartItemLogic cartItemLogic)
        {
            _foodItemLogic = foodItemLogic;
            _cartItemLogic = cartItemLogic;
            _logger = logger;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View();
        }
        public async Task<IActionResult> RemoveCart(int id)
        {
            var response = await _cartItemLogic.RemoveCart(id);

            return await Cart();
        }
        public async Task<IActionResult> Cart()
        {

            var response = await _cartItemLogic.GetAllCart();
            if (response != null)
            {
                return View("ShoppingCart", response);
            }
            return null;
        }
        public async Task<IActionResult> AddToCart(CartItem cartItem)
        {
            var response = await _cartItemLogic.CreateNewCart(cartItem);
            return await Cart();
        }
        public async Task<IActionResult> CheckOut()
        {
            var response = await _cartItemLogic.GetAllCart();
            if (response != null)
            {
                return View("Checkout", response);
            }
            return null;

        }
    }
}
