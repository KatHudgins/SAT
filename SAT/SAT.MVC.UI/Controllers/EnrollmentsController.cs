using System;
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
    public class EnrollmentsController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Enrollments
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Scheduling"))
            {
                var enrollments = db.Enrollments.Include(e => e.ScheduledClass).Include(e => e.Student).Include(e => e.ScheduledClass.Cours);
                return View(enrollments.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
           

        }

        // GET: Enrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("Admin") || (User.IsInRole("Scheduling")))
            {
                return View(enrollment);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        // GET: Enrollments/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Scheduling"))
            {
                ViewBag.ScheduledClassId = new SelectList(db.ScheduledClasses, "ScheduledClassId", "InstructorName");
                ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
           
            
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentId,StudentId,ScheduledClassId,EnrollmentDate")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ScheduledClassId = new SelectList(db.ScheduledClasses, "ScheduledClassId", "InstructorName", enrollment.ScheduledClassId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("Admin") || User.IsInRole("Scheduling"))
            {
                ViewBag.ScheduledClassId = new SelectList(db.ScheduledClasses, "ScheduledClassId", "InstructorName", enrollment.ScheduledClassId);
                ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", enrollment.StudentId);
                return View(enrollment);
            }
            else
            {
                return RedirectToAction("Login", "Enrollment");
            }
            
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentId,StudentId,ScheduledClassId,EnrollmentDate")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScheduledClassId = new SelectList(db.ScheduledClasses, "ScheduledClassId", "InstructorName", enrollment.ScheduledClassId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }

            if (User.IsInRole("Admin") || User.IsInRole("Scheduling"))
            {
                return View(enrollment);
            }
            else
            {
                return RedirectToAction("Login", "Enrollment");
            }
           
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.IsInRole("Admin") || (User.IsInRole("Scheduling")))
            {
                Enrollment enrollment = db.Enrollments.Find(id);
                db.Enrollments.Remove(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
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
