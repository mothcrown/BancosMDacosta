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
    public class ClientesController : Controller {
        private BancosDAL dbContext = new BancosDAL();

        // GET: Clientes
        public ActionResult Index() {
            return View();
        }

        public ActionResult Get() {
            return View(dbContext.Clientes);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Clientes cliente) {
            String view = "Create";
            if (ModelState.IsValid) {
                dbContext.Clientes.Add(cliente);
                dbContext.SaveChanges();
                view = "Get";
            }
            return RedirectToAction(view);
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            Clientes cliente = dbContext.Clientes.Find(id);

            if (cliente == null) {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Clientes cliente) {
            String view = "Edit";
            if (ModelState.IsValid) {
                dbContext.Entry(cliente).State = EntityState.Modified;
                dbContext.SaveChanges();
                view = "Get";
            }
            return RedirectToAction(view);
        }

        [HttpGet]
        public ActionResult Details(int id) {
            Clientes cliente = dbContext.Clientes.Find(id);
            if (cliente == null) {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpGet]
        public ActionResult Delete(int id) {
            Clientes cliente = dbContext.Clientes.Find(id);
            if (cliente == null) {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id) {
            Clientes cliente = dbContext.Clientes.Find(id);
            dbContext.Clientes.Remove(cliente);
            dbContext.SaveChanges();

            String view = "Get";
            return RedirectToAction(view);
        }
    }
}