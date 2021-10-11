using Laptop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laptop.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class Autorizacion : AuthorizeAttribute
    {
        private usuario oUsuario;
        private MiSistemaEntities db = new MiSistemaEntities();
        private int idOperacion;

        public Autorizacion(int idOperacione = 0)
        {
            this.idOperacion = idOperacione;           
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);

            try
            {
                oUsuario = (usuario)HttpContext.Current.Session["User"];
                var lstOperaciones = from m in db.rol_operacion
                                     where m.idRol == oUsuario.idRol
                                     && m.idOperacion == this.idOperacion
                                     select m;

                if (lstOperaciones.ToList().Count() == 0)
                {
                    filterContext.Result = new RedirectResult("~/Error/Noautorizado");
                }


            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/Noautorizado");
            }
            

        }


    }
}