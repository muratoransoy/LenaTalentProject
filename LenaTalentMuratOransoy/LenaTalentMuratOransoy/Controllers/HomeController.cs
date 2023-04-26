using LenaTalent.DAL.Abstract;
using LenaTalent.DAL.Concrete;
using LenaTalent.Entities.Models.Entities;
using LenaTalentMuratOransoy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LenaTalentMuratOransoy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFormDAL formDAL;

        public HomeController(ILogger<HomeController> logger, IFormDAL formDAL)
        {
            _logger = logger;
            this.formDAL = formDAL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Form form)
        {

            formDAL.Add(form);
            return RedirectToAction("Index");


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