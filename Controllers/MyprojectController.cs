using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Myproject.Models;

namespace Myproject.Controllers
{
    public class MyprojectController : Controller
    {
        private MyprojectEntities db = new MyprojectEntities();

        // GET: Myproject
        public ActionResult Index()
        {
            return View(db.list_table.ToList());
        }

        // GET: Myproject/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            list_table list_table = db.list_table.Find(id);
            if (list_table == null)
            {
                return HttpNotFound();
            }
            return View(list_table);
        }

        // GET: Myproject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Myproject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,id_number,title,description,status")] list_table list_table)
        {
            if (ModelState.IsValid)
            {
                db.list_table.Add(list_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(list_table);
        }

        // GET: Myproject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            list_table list_table = db.list_table.Find(id);
            if (list_table == null)
            {
                return HttpNotFound();
            }
            return View(list_table);
        }

        // POST: Myproject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,id_number,title,description,status")] list_table list_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(list_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(list_table);
        }

        // GET: Myproject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            list_table list_table = db.list_table.Find(id);
            if (list_table == null)
            {
                return HttpNotFound();
            }
            return View(list_table);
        }

        // POST: Myproject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            list_table list_table = db.list_table.Find(id);
            db.list_table.Remove(list_table);
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
