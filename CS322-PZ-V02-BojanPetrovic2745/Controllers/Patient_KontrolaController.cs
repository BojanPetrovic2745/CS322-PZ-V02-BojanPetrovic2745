using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS322_PZ_V02_BojanPetrovic2745;

namespace CS322_PZ_V02_BojanPetrovic2745.Controllers
{
    [Authorize]
    public class Patient_KontrolaController : Controller
    {
        private Model1 db = new Model1();

        // GET: Patient_Kontrola
        public async Task<ActionResult> Index()
        {
            var patient_Kontrola = db.Patient_Kontrola.Include(p => p.Kontrola).Include(p => p.Patient);
            return View(await patient_Kontrola.ToListAsync());
        }

        // GET: Patient_Kontrola/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Kontrola patient_Kontrola = await db.Patient_Kontrola.FindAsync(id);
            if (patient_Kontrola == null)
            {
                return HttpNotFound();
            }
            return View(patient_Kontrola);
        }

        // GET: Patient_Kontrola/Create
        public ActionResult Create()
        {
            ViewBag.KontroalD = new SelectList(db.Kontrolas, "IDkon", "IDkon");
            ViewBag.PatientID = new SelectList(db.Patients, "IDpa", "ime");
            return View();
        }

        // POST: Patient_Kontrola/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,PatientID,KontroalD")] Patient_Kontrola patient_Kontrola)
        {
            if (ModelState.IsValid)
            {
                db.Patient_Kontrola.Add(patient_Kontrola);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.KontroalD = new SelectList(db.Kontrolas, "IDkon", "IDkon", patient_Kontrola.KontroalD);
            ViewBag.PatientID = new SelectList(db.Patients, "IDpa", "ime", patient_Kontrola.PatientID);
            return View(patient_Kontrola);
        }

        // GET: Patient_Kontrola/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Kontrola patient_Kontrola = await db.Patient_Kontrola.FindAsync(id);
            if (patient_Kontrola == null)
            {
                return HttpNotFound();
            }
            ViewBag.KontroalD = new SelectList(db.Kontrolas, "IDkon", "IDkon", patient_Kontrola.KontroalD);
            ViewBag.PatientID = new SelectList(db.Patients, "IDpa", "ime", patient_Kontrola.PatientID);
            return View(patient_Kontrola);
        }

        // POST: Patient_Kontrola/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,PatientID,KontroalD")] Patient_Kontrola patient_Kontrola)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient_Kontrola).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.KontroalD = new SelectList(db.Kontrolas, "IDkon", "IDkon", patient_Kontrola.KontroalD);
            ViewBag.PatientID = new SelectList(db.Patients, "IDpa", "ime", patient_Kontrola.PatientID);
            return View(patient_Kontrola);
        }

        // GET: Patient_Kontrola/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Kontrola patient_Kontrola = await db.Patient_Kontrola.FindAsync(id);
            if (patient_Kontrola == null)
            {
                return HttpNotFound();
            }
            return View(patient_Kontrola);
        }

        // POST: Patient_Kontrola/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Patient_Kontrola patient_Kontrola = await db.Patient_Kontrola.FindAsync(id);
            db.Patient_Kontrola.Remove(patient_Kontrola);
            await db.SaveChangesAsync();
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
