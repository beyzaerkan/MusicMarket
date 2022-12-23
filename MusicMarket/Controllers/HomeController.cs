using Microsoft.AspNetCore.Mvc;
using MusicMarket.Models;
using System.Diagnostics;

namespace MusicMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;

        public HomeController(DataContext context)
        {
            this._dataContext = context;
        }

        public IActionResult Index()
        {
            var products = _dataContext.Products.ToList();
            return View(products);
        }


        public IActionResult Contact()
        {
            return View();
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