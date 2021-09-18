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
    public class TransaccionsController : Controller
    {
        private BancoDB db = new BancoDB();

        // GET: Transaccions
        public ActionResult Index()
        {
            var transacciones = db.Transacciones.Include(t => t.Cuenta).Include(t => t.Tipo);
            return View(transacciones.ToList());
        }

        // GET: Transaccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transacciones.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: Transaccions/Create
        public ActionResult Create()
        {
            ViewBag.CuentaId = new SelectList(db.Cuentas, "Id", "Moneda");
            ViewBag.TipoId = new SelectList(db.TransaccionTipos, "Id", "Nombre");
            return View();
        }

        // POST: Transaccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Monto,Estado,FechaTransaccion,FechaAplicacion,CuentaId,TipoId")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Transacciones.Add(transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CuentaId = new SelectList(db.Cuentas, "Id", "Moneda", transaccion.CuentaId);
            ViewBag.TipoId = new SelectList(db.TransaccionTipos, "Id", "Nombre", transaccion.TipoId);
            return View(transaccion);
        }

        // GET: Transaccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transacciones.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CuentaId = new SelectList(db.Cuentas, "Id", "Moneda", transaccion.CuentaId);
            ViewBag.TipoId = new SelectList(db.TransaccionTipos, "Id", "Nombre", transaccion.TipoId);
            return View(transaccion);
        }

        // POST: Transaccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Monto,Estado,FechaTransaccion,FechaAplicacion,CuentaId,TipoId")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CuentaId = new SelectList(db.Cuentas, "Id", "Moneda", transaccion.CuentaId);
            ViewBag.TipoId = new SelectList(db.TransaccionTipos, "Id", "Nombre", transaccion.TipoId);
            return View(transaccion);
        }

        // GET: Transaccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transacciones.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaccion transaccion = db.Transacciones.Find(id);
            db.Transacciones.Remove(transaccion);
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
