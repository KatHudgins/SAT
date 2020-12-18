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
    public class CoursController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Cours
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View(db.Courses.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        // GET: Cours/Details/5
        public ActionResult Details(int? id)
        {
            if (User.IsInRole("Admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cours cours = db.Courses.Find(id);
                if (cours == null)
                {
                    return HttpNotFound();
                }
                return View(cours);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        // GET: Cours/Create
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

        // POST: Cours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseName,CourseDescription,CreditHours,Curriculum,Notes,IsActive")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(cours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cours);
        }

        // GET: Cours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.IsInRole("Admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cours cours = db.Courses.Find(id);
                if (cours == null)
                {
                    return HttpNotFound();
                }
                return View(cours);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        // POST: Cours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseName,CourseDescription,CreditHours,Curriculum,Notes,IsActive")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cours);
        }

        // GET: Cours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.IsInRole("Admin"))
            {
                Cours cours = db.Courses.Find(id);
                db.Courses.Remove(cours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
           
        }

        [HttpGet]
        public ActionResult ActiveCours()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Scheduling"))
            {
                return View(db.Courses.Where(c => c.IsActive == true).ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public ActionResult NonActiveCours()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Scheduling"))
            {
                return View(db.Courses.Where(c => c.IsActive == false).ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }


        //[HttpGet]
        //public ActionResult FilteredCours(string curriculum)
        //{
        //    return View(db.Courses.Where(c => c.Curriculum.Contains(curriculum)).ToList());
        //}
        
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
