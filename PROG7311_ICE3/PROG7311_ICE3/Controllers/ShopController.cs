using PROG7311_ICE3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace PROG7311_ICE3.Controllers
{
    public class ShopController : Controller 
    {
        private readonly ProductRepository _repo;
        private readonly OrderService _orderService;

        // Cart is stored in-memory on the service (injected as singleton)
        private static List<CartItem> _cart = new List<CartItem>();

        public ShopController(ProductRepository repo, OrderService orderService)
        {
            _repo = repo;
            _orderService = orderService;
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-ZA");
        }

        // GET /Shop/Index — Show all products
        public IActionResult Index()
        {
            var products = _repo.GetAll();
            return View(products);
        }

        // POST /Shop/AddToCart — Add product to cart
        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = _repo.GetById(productId);
            if (product != null)
            {
                var existing = _cart.FirstOrDefault(c => c.Product.Id == productId);
                if (existing != null)
                    existing.Quantity++;
                else
                    _cart.Add(new CartItem { Product = product, Quantity = 1 });
            }
            return RedirectToAction("Cart");
        }

        // GET /Shop/Cart — View cart
        public IActionResult Cart()
        {
            return View(_cart);
        }

        // POST /Shop/RemoveFromCart — Remove item from cart
        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var item = _cart.FirstOrDefault(c => c.Product.Id == productId);
            if (item != null) _cart.Remove(item);
            return RedirectToAction("Cart");
        }

        // POST /Shop/Checkout — Place the order
        [HttpPost]
        public IActionResult Checkout()
        {
            if (!_cart.Any())
                return RedirectToAction("Cart");

            var order = new Order { Items = new List<CartItem>(_cart) };
            _orderService.PlaceOrder(order);
            _cart.Clear();

            return RedirectToAction("Confirmation", new { orderId = order.Id, total = order.Total });
        }

        // GET /Shop/Confirmation — Show confirmation
        public IActionResult Confirmation(int orderId, decimal total)
        {
            ViewBag.OrderId = orderId;
            ViewBag.Total = total.ToString("C", new CultureInfo("en-ZA"));
            return View();
        }
    }
}
