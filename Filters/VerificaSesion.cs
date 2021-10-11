using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Laptop.Models;
using Laptop.Controllers;

namespace Laptop.Filters
{
    public class VerificaSesion : ActionFilterAttribute
    {
        private usuario oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            oUsuario = (usuario) HttpContext.Current.Session["User"];
            if(oUsuario == null)
            {
                if(filterContext.Controller is AccesoController == false)
                {
                    filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                }
            }

        }
    }
}