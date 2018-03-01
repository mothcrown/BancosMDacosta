using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BancosMDacosta.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(String returnUrl) {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(BancoUsers usuario, string returnUrl) {
            if (ModelState.IsValid) {
                BancoUsers authUser = null;
                using (BancosEntities contexto = new BancosEntities()) {
                    authUser = contexto.BancoUsers.FirstOrDefault(u => u.Login == usuario.Login && u.Password == usuario.Password);
                }
                if (authUser != null) {
                    FormsAuthentication.SetAuthCookie(authUser.Login, false);
                    Session["USUARIO"] = authUser;
                    return Redirect(returnUrl);
                }
                else {
                    ModelState.AddModelError("CredentialError", "Usuario o contraseña incorrectos");
                    return View();
                }
            }
            else {
                return View();
            }
            
        }

        public ActionResult LogOut() {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


    }
}