using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMarket.Data;
using MusicMarket.Data.Static;
using MusicMarket.Models;
using System;

namespace MusicMarket.Controllers
{
    [Authorize(Roles = UserRoles.User)]
    public class OrderController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<MusicMarketUser> _userManager;
        private const string SessionKey = "Cart";

        public OrderController(DataContext context, IHttpContextAccessor contextAccessor, UserManager<MusicMarketUser> userManager)
        {
            this._dataContext = context;
            this._contextAccessor = contextAccessor;
            this._userManager = userManager;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = await _dataContext.Orders.Include(n => n.OrderDetails).ThenInclude(n => n.Product).Include(n => n.User).ToListAsync();

            return View(orders);
        }

        public ActionResult Confirmation()
        {
            return View();
        }

        // GET: Order/Create
        public async Task<IActionResult> Create()
        {
            List<CartItem> cart = _contextAccessor.HttpContext.Session.Get<List<CartItem>>(SessionKey);
            var user = await _userManager.GetUserAsync(User);
            var order = new Order()
            {
                UserId = user.Id,
                OrderNumber = Guid.NewGuid().ToString(),
                Total = cart.Sum(item => item.Product.Price * item.Quantity),
                OrderDate = DateTime.Now
            };
            await _dataContext.Orders.AddAsync(order);
            await _dataContext.SaveChangesAsync();

            foreach (var item in cart)
            {
                var orderDetail = new OrderDetail()
                {
                    OrderId = order.Id,
                    ProductId = item.Product.Id,
                    Quantity = item.Quantity,
                    Price = item.Product.Price * item.Quantity,
                };
                await _dataContext.OrderDetails.AddAsync(orderDetail);
            }
            await _dataContext.SaveChangesAsync();
            cart.Clear();
            _contextAccessor.HttpContext.Session.Set<List<CartItem>>(SessionKey, cart);

            return RedirectToAction(nameof(Confirmation));
        }
    }
}
