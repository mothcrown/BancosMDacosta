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
    public class CuentasController : Controller
    {
        private BancosDAL dbContext = new BancosDAL();

        // GET: Cuentas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get() {
            return View(dbContext.Cuentas);
        }

        [HttpGet]
        public ActionResult Create() {
            if (ModelState.IsValid) {
                ViewBag.IdCliente = new SelectList(dbContext.Clientes.OrderBy(x => x.NifNie), "IdCliente", "NifNie");
                ViewBag.IdEntidad = new SelectList(dbContext.Entidades.OrderBy(x => x.CodEntidad), "IdEntidad", "CodEntidad");
                ViewBag.IdTipoCuenta = new SelectList(dbContext.TiposCuenta.OrderBy(x => x.Denominacion), "IdTipoCuenta", "Denominacion");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cuentas cuenta) {
            String view = "Create";
            if (ModelState.IsValid) {
                dbContext.Cuentas.Add(cuenta);
                dbContext.SaveChanges();
                view = "Get";
            }
            return RedirectToAction(view);
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            Cuentas cuenta = dbContext.Cuentas.Find(id);
            ViewBag.IdCliente = new SelectList(dbContext.Clientes.OrderBy(x => x.NifNie), "IdCliente", "NifNie");
            ViewBag.IdEntidad = new SelectList(dbContext.Entidades.OrderBy(x => x.CodEntidad), "IdEntidad", "CodEntidad");
            ViewBag.IdTipoCuenta = new SelectList(dbContext.TiposCuenta.OrderBy(x => x.Denominacion), "IdTipoCuenta", "Denominacion");

            if (cuenta == null) {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        [HttpPost]
        public ActionResult Edit(Cuentas cuenta) {
            String view = "Edit";
            if (ModelState.IsValid) {
                dbContext.Entry(cuenta).State = EntityState.Modified;
                dbContext.SaveChanges();
                view = "Get";
            }
            return RedirectToAction(view);
        }

        [HttpGet]
        public ActionResult Details(int id) {
            Cuentas cuenta = dbContext.Cuentas.Find(id);
            if (cuenta == null) {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        [HttpGet]
        public ActionResult Delete(int id) {
            Cuentas cuenta = dbContext.Cuentas.Find(id);
            if (cuenta == null) {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id) {
            Cuentas cuenta = dbContext.Cuentas.Find(id);
            dbContext.Cuentas.Remove(cuenta);
            dbContext.SaveChanges();

            String view = "Get";
            return RedirectToAction(view);
        }
    }
}