using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Laptop.Filters;

namespace Laptop.Controllers
{
    public class HomeController : Controller
    {
        [Autorizacion(idOperacione: 14)]
        public ActionResult Index()
        {
            return View();
        }

        [Autorizacion(idOperacione: 3)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Autorizacion(idOperacione: 3)]
        public ActionResult Contact()
        {

            string contrasena = Encrypt.GetSHA256("crush");

            ViewBag.Message = "Encriptado:  "+contrasena;

            return View();
        }
    }
}