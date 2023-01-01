using AspNetCoreMultilingual.Languages;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MusicMarket.Data;
using MusicMarket.Models;
using System.Diagnostics;

namespace MusicMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IStringLocalizer<Lang> _stringLocalizer;
        public HomeController(IStringLocalizer<Lang> stringLocalizer, DataContext context)
        {
            _stringLocalizer = stringLocalizer;
            this._dataContext = context;
        }
        public IActionResult SetAppLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult SetCulture(string id = "en")
        {
            string culture = id;
            Response.Cookies.Append(
               CookieRequestCultureProvider.DefaultCookieName,
               CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
               new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
           );

            ViewData["Message"] = "Culture set to " + culture;

            return View();
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