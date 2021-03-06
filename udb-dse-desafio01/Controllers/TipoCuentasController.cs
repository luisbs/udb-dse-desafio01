using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using udb_dse_desafio01.Models;

namespace udb_dse_desafio01.Controllers
{
    public class TipoCuentasController : Controller
    {
        private BancoDB db = new BancoDB();

        // GET: TipoCuentas
        public ActionResult Index()
        {
            return View(db.CuentaTipos.ToList());
        }

        // GET: TipoCuentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCuenta tipoCuenta = db.CuentaTipos.Find(id);
            if (tipoCuenta == null)
            {
                return HttpNotFound();
            }
            return View(tipoCuenta);
        }

        // GET: TipoCuentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCuentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Activo")] TipoCuenta tipoCuenta)
        {
            if (ModelState.IsValid)
            {
                db.CuentaTipos.Add(tipoCuenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCuenta);
        }

        // GET: TipoCuentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCuenta tipoCuenta = db.CuentaTipos.Find(id);
            if (tipoCuenta == null)
            {
                return HttpNotFound();
            }
            return View(tipoCuenta);
        }

        // POST: TipoCuentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Activo")] TipoCuenta tipoCuenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCuenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCuenta);
        }

        // GET: TipoCuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCuenta tipoCuenta = db.CuentaTipos.Find(id);
            if (tipoCuenta == null)
            {
                return HttpNotFound();
            }
            return View(tipoCuenta);
        }

        // POST: TipoCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCuenta tipoCuenta = db.CuentaTipos.Find(id);
            db.CuentaTipos.Remove(tipoCuenta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
