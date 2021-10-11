using Laptop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laptop.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        [HttpGet]
        public ActionResult Login()
        {
            usuario oUsuario;
            oUsuario = (usuario) Session["User"];
            if (oUsuario == null)
                return View();
            return RedirectToAction("About", "Home");
        }
        
        [HttpPost]
        public ActionResult Login(string usuario, string contrasena)
        {
            try
            {
                using (MiSistemaEntities db = new MiSistemaEntities())
                {
                    var oUser = (from d in db.usuario
                                 where d.email == usuario.Trim() && d.password == contrasena.Trim()
                                 select d
                                 ).FirstOrDefault();

                    if(oUser == null)
                    {
                        ViewBag.Error = "susuario y contrasena invalido";
                        return View();
                    }

                    Session["User"] = oUser;
                    
                }
                return RedirectToAction("About", "Home");


            }catch(Exception ex)
            {
                return View();
            }

        }



    }
}