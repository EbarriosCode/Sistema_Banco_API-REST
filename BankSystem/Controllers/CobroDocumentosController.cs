using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BankSystem.Models;

namespace BankSystem.Controllers
{
    public class CobroDocumentosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: CobroDocumentos
        public ActionResult Index()
        {
            var cobroDocumento = db.CobroDocumento.Include(c => c.CuentaBancaria);
            return View(cobroDocumento.ToList());
        }

        // GET: CobroDocumentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CobroDocumento cobroDocumento = db.CobroDocumento.Find(id);
            if (cobroDocumento == null)
            {
                return HttpNotFound();
            }
            return View(cobroDocumento);
        }

        // GET: CobroDocumentos/Create
        public ActionResult Create()
        {
            ViewBag.NumeroCuenta = new SelectList(db.CuentaBancaria, "NumeroCuenta", "NombreCuenta");
            return View();
        }

        // POST: CobroDocumentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCobroDocumento,Documento,NumeroCuenta,CantidadCobro,MesDePago")] CobroDocumento cobroDocumento)
        {
            if (ModelState.IsValid)
            {
                db.CobroDocumento.Add(cobroDocumento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NumeroCuenta = new SelectList(db.CuentaBancaria, "NumeroCuenta", "NombreCuenta", cobroDocumento.NumeroCuenta);
            return View(cobroDocumento);
        }

        // GET: CobroDocumentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CobroDocumento cobroDocumento = db.CobroDocumento.Find(id);
            if (cobroDocumento == null)
            {
                return HttpNotFound();
            }
            ViewBag.NumeroCuenta = new SelectList(db.CuentaBancaria, "NumeroCuenta", "NombreCuenta", cobroDocumento.NumeroCuenta);
            return View(cobroDocumento);
        }

        // POST: CobroDocumentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCobroDocumento,Documento,NumeroCuenta,CantidadCobro,MesDePago")] CobroDocumento cobroDocumento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cobroDocumento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NumeroCuenta = new SelectList(db.CuentaBancaria, "NumeroCuenta", "NombreCuenta", cobroDocumento.NumeroCuenta);
            return View(cobroDocumento);
        }

        // GET: CobroDocumentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CobroDocumento cobroDocumento = db.CobroDocumento.Find(id);
            if (cobroDocumento == null)
            {
                return HttpNotFound();
            }
            return View(cobroDocumento);
        }

        // POST: CobroDocumentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CobroDocumento cobroDocumento = db.CobroDocumento.Find(id);
            db.CobroDocumento.Remove(cobroDocumento);
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
