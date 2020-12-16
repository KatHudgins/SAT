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
            return View(db.Courses.ToList());
        }

        // GET: Cours/Details/5
        public ActionResult Details(int? id)
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

        // GET: Cours/Create
        public ActionResult Create()
        {
            return View();
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
            Cours cours = db.Courses.Find(id);
            db.Courses.Remove(cours);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Cours/Get/Art
        [HttpGet]
        public ActionResult ArtCours(string curriculum)
        {

            return View(db.Courses.Where(c => c.Curriculum == "Art and Graphics Design").ToList());
        }
        //Cours/Get/Biology
        [HttpGet]
        public ActionResult BiologyCours(string curriculum)
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Biology")).ToList());
        }

        //Cours/Get/BioChem
        [HttpGet]
        public ActionResult BioChemCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("BioChemistry")).ToList());
        }

        //Cours/Get/Chem
        [HttpGet]
        public ActionResult ChemCours()
        {
            return View(db.Courses.Where(c => c.Curriculum == "Chemistry").ToList());
        }

        //Cours/Get/CompScience
        [HttpGet]
        public ActionResult CompScienceCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Computer Science")).ToList());
        }

        //Cours/Get/English
        [HttpGet]
        public ActionResult EnglishCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("English")).ToList());
        }

        //Cours/Get/Forensics
        [HttpGet]
        public ActionResult ForensicCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Forensics")).ToList());
        }

        //Cours/Get/CyberSecurity
        [HttpGet]
        public ActionResult CyberSecurityCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Cyber Security")).ToList());
        }

        //Cours/Get/Education
        [HttpGet]
        public ActionResult EducationCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Education")).ToList());
        }

        //Cours/Get/Finance
        [HttpGet]
        public ActionResult FinanceCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Finance")).ToList());
        }

        //Cours/Get/Management
        [HttpGet]
        public ActionResult ManagementCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Management")).ToList());
        }

        //Cours/Get/History
        [HttpGet]
        public ActionResult HistoryCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("History")).ToList());
        }

        //Cours/Get/IntBusiness
        [HttpGet]
        public ActionResult IntBusinessCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("International Business")).ToList());
        }
        
        //Cours/Get/Marketing
        [HttpGet]
        public ActionResult MarketingCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Marketing")).ToList());
        }

        //Cours/Get/Math
        [HttpGet]
        public ActionResult MathCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Mathematics")).ToList());
        }

        //Cours/Get/Music
        [HttpGet]
        public ActionResult MusicCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Music")).ToList());
        }

        //Cours/Get/Nursing
        [HttpGet]
        public ActionResult NursingCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Nursing")).ToList());
        }

        //Cours/Get/Philosophy
        [HttpGet]
        public ActionResult PhilosophyCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Philosophy")).ToList());
        }

        //Cours/Get/Political Science
        [HttpGet]
        public ActionResult PolScienceCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Political Science")).ToList());
        }

        //Cours/Get/Accounting
        [HttpGet]
        public ActionResult AccountingCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Accounting")).ToList());
        }

        //Cours/Get/EnvScience
        [HttpGet]
        public ActionResult EnvScienceCours()
        {
            return View(db.Courses.Where(c => c.Curriculum.Contains("Environmental Science")).ToList());
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
