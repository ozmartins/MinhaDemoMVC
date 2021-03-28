using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaDemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaDemoMVC.Controllers
{
    [Route("")]
    [Route("sales")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("list/{id:int}/{category:int?}")]
        public IActionResult Index(int id, int category)
        {
            var movie = new Movie()
            {
                Title = "Hi",
                ReleaseDate = DateTime.Now,
                Genre = null,
                Grade = 10,
                Price = 200000
            };

            return RedirectToAction("Privacy", movie);
            //return View();
        }

        [Route("privacy")]
        public IActionResult Privacy(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var msg = "";

                foreach (var erro in ModelState.Values.SelectMany(v => v.Errors))
                {
                    msg += erro.ErrorMessage + "\n";
                }

                return Content(msg);
            }
            //return Json("{nome: Oseias}");
            // var fileBytes = System.IO.File.ReadAllBytes(@"D:\Pedido.pdf");
            //var fileName = "Pedido.pdf";
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            return Content("Teste");
        }

        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
