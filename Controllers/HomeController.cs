using GestaoHoteis.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestaoHoteis.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            HomeModel home = new HomeModel();

            home.Nome = "Castles Hotel";
            home.CNPJ = "15.456.200/0001-50";

            return View(home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Reservas()
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