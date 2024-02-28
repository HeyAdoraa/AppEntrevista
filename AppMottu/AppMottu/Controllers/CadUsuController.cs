using AppMottu.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppMottu.Controllers
{
    public class CadUsuController : Controller
    {
        private readonly ILogger<CadUsuController> _logger;



        public IActionResult CadMoto()
        {
            return View();
        }
    }
}
