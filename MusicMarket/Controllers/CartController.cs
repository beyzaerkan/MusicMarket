using MusicMarket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using MessagePack;
using MusicMarket.Data;

namespace MusicMarket.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly DataContext _context;
        private const string SessionKey = "Cart";

        public CartController(IHttpContextAccessor contextAccessor, DataContext context)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            List<CartItem> cart = _contextAccessor.HttpContext.Session.Get<List<CartItem>>(SessionKey) ?? new List<CartItem>();
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View(cart.ToList());
        }
        

        public async Task<IActionResult> AddToCart(int Id)
        {
            Product product = await _context.Products.FindAsync(Id);
            List<CartItem> cart = _contextAccessor.HttpContext.Session.Get<List<CartItem>>(SessionKey) ?? new List<CartItem>();
            CartItem item = cart.Where(x => x.Product.Id == Id).FirstOrDefault();
            if (item == null)
            {
                cart.Add(new CartItem()
                {
                    Product = product,
                    Quantity = 1
                });
            }
            else
            {
                item.Quantity += 1;
            }

            _contextAccessor.HttpContext.Session.Set<List<CartItem>>(SessionKey, cart);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Remove(int Id)
        {
            List<CartItem> cart = _contextAccessor.HttpContext.Session.Get<List<CartItem>>(SessionKey) ?? new List<CartItem>();
            CartItem item = cart.Where(x => x.Product.Id == Id).FirstOrDefault();
            if (item != null)
            {
                if(item.Quantity == 1)
                {
                    cart.Remove(item);
                }
                else
                {
                    item.Quantity--;
                }
            }
            _contextAccessor.HttpContext.Session.Set<List<CartItem>>(SessionKey, cart);

            return RedirectToAction("Index");
        }
    }
}
