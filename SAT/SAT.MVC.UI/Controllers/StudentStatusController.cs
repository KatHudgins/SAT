﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAT.MVC.DATA;

namespace SAT.MVC.UI.Controllers
{
    public class StudentStatusController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: StudentStatus
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View(db.StudentStatuses.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: StudentStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (User.IsInRole("Admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                StudentStatus studentStatus = db.StudentStatuses.Find(id);
                if (studentStatus == null)
                {
                    return HttpNotFound();
                }
                return View(studentStatus);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: StudentStatus/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: StudentStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SSID,SSName,SSDescription")] StudentStatus studentStatus)
        {
            if (ModelState.IsValid)
            {
                db.StudentStatuses.Add(studentStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentStatus);
        }

        // GET: StudentStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.IsInRole("Admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                StudentStatus studentStatus = db.StudentStatuses.Find(id);
                if (studentStatus == null)
                {
                    return HttpNotFound();
                }
                return View(studentStatus);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: StudentStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SSID,SSName,SSDescription")] StudentStatus studentStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentStatus);
        }

        // GET: StudentStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (User.IsInRole("Admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                StudentStatus studentStatus = db.StudentStatuses.Find(id);
                if (studentStatus == null)
                {
                    return HttpNotFound();
                }
                return View(studentStatus);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: StudentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentStatus studentStatus = db.StudentStatuses.Find(id);
            db.StudentStatuses.Remove(studentStatus);
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
