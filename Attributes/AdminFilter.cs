using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancosMDacosta.Attributes {
    public class AdminFilter : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            BancoUsers user = null;
            if (filterContext.HttpContext.Session["USUARIO"] is BancoUsers) {
                user = filterContext.HttpContext.Session["USUARIO"] as BancoUsers;
            }
            if (user == null || !user.Grupos.Split('|').Any(i => i == "ADMIN")) {
                filterContext.Result = new ViewResult() {
                    ViewName = "AuthError"
                };
            }
        }
    }
}