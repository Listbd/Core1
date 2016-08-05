using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core1.Controllers
{
    public class HomeController : Controller
    {
        private IViewModelService _viewModelService;
        public HomeController(IViewModelService viewModelService)
        {
            _viewModelService = viewModelService;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Core Test Dashboard";
            return View();
        }
    }
}
