﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DrugsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Drugs
        public ActionResult Index()
        {
            return View(db.Drugs.ToList());
        }

        // GET: Drugs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drugs drugs = db.Drugs.Find(id);
            if (drugs == null)
            {
                return HttpNotFound();
            }
            return View(drugs);
        }

        // GET: Drugs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drugs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DrugsID,drugName")] Drugs drugs)
        {
            if (ModelState.IsValid)
            {
                db.Drugs.Add(drugs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drugs);
        }

        // GET: Drugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drugs drugs = db.Drugs.Find(id);
            if (drugs == null)
            {
                return HttpNotFound();
            }
            return View(drugs);
        }

        // POST: Drugs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrugsID,drugName")] Drugs drugs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drugs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drugs);
        }

        // GET: Drugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drugs drugs = db.Drugs.Find(id);
            if (drugs == null)
            {
                return HttpNotFound();
            }
            return View(drugs);
        }

        // POST: Drugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drugs drugs = db.Drugs.Find(id);
            db.Drugs.Remove(drugs);
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
