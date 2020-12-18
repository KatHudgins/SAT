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
    public class ScheduledClassesController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: ScheduledClasses
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Scheduling"))
            {
                var scheduledClasses = db.ScheduledClasses.Include(s => s.Cours).Include(s => s.ScheduledClassStatus);
                return View(scheduledClasses.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        // GET: ScheduledClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Scheduling"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ScheduledClass scheduledClass = db.ScheduledClasses.Find(id);
                if (scheduledClass == null)
                {
                    return HttpNotFound();
                }
                return View(scheduledClass);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
           
        }

        // GET: ScheduledClasses/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Scheduling"))
            {
                ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
                ViewBag.SCSID = new SelectList(db.ScheduledClassStatuses, "SCSID", "SCSName");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        // POST: ScheduledClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduledClassId,CourseId,StartDate,EndDate,InstructorName,Location,SCSID")] ScheduledClass scheduledClass)
        {
            if (ModelState.IsValid)
            {
                db.ScheduledClasses.Add(scheduledClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", scheduledClass.CourseId);
            ViewBag.SCSID = new SelectList(db.ScheduledClassStatuses, "SCSID", "SCSName", scheduledClass.SCSID);
            return View(scheduledClass);
        }

        // GET: ScheduledClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Scheduling"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ScheduledClass scheduledClass = db.ScheduledClasses.Find(id);
                if (scheduledClass == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", scheduledClass.CourseId);
                ViewBag.SCSID = new SelectList(db.ScheduledClassStatuses, "SCSID", "SCSName", scheduledClass.SCSID);
                return View(scheduledClass);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
           
        }

        // POST: ScheduledClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheduledClassId,CourseId,StartDate,EndDate,InstructorName,Location,SCSID")] ScheduledClass scheduledClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduledClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", scheduledClass.CourseId);
            ViewBag.SCSID = new SelectList(db.ScheduledClassStatuses, "SCSID", "SCSName", scheduledClass.SCSID);
            return View(scheduledClass);
        }

        // GET: ScheduledClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (User.IsInRole("Admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ScheduledClass scheduledClass = db.ScheduledClasses.Find(id);
                if (scheduledClass == null)
                {
                    return HttpNotFound();
                }
                return View(scheduledClass);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
           
        }

        // POST: ScheduledClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.IsInRole("Admin"))
            {
                ScheduledClass scheduledClass = db.ScheduledClasses.Find(id);
                db.ScheduledClasses.Remove(scheduledClass);
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
