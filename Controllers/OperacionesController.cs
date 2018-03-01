using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BancosMDacosta.DataAccessLayer;
using BancosMDacosta.Attributes;

namespace BancosMDacosta.Controllers
{
    [Authorize]
    [AdminFilter]
    public class OperacionesController : Controller
    {
        private BancosDAL dbContext = new BancosDAL();

        // GET: Operaciones
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(int id) {
            Operaciones operacion = new Operaciones();
            operacion.IdCliente = id;
            return View(operacion);
        }

        [HttpPost]
        public ActionResult Create(Operaciones operacion) {
            if (ModelState.IsValid) {
                dbContext.Operaciones.Add(operacion);
                dbContext.SaveChanges();
                return RedirectToAction("Get", "Clientes");
            }
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            return View();
        }
    }
}