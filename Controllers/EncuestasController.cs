using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Proyecto_Web_MVC.Models;

namespace Proyecto_Web_MVC.Controllers
{
    public class EncuestasController : Controller
    {
        public EncuestasController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}