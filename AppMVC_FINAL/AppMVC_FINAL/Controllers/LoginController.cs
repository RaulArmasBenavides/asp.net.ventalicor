using AppMVC_FINAL.Bussines;
using AppMVC_FINAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMVC_FINAL.Controllers
{
    public class LoginController : Controller
    {
        //instanciar objeto de la clase ComprobanteBll
        ComprobanteBll obj = new ComprobanteBll();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autenticar(Usuarios user)
        {
            try
            {
            //return View(obj.validar(user));
                Usuarios usuario1 = obj.validar(user);
                if (usuario1 == null)
                {
                    user.LoginErrorMessage = "Usuario o Password es Incorrecto.";
                    return View("Index", user);
                }
                else
                {
                    Session["userID"] = usuario1.Id;
                    Session["userName"] = usuario1.Nombre;
                    return RedirectToAction("Index", "Principal");
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}