using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CS322_PZ_V02_BojanPetrovic2745
{
    [Authorize]
    public class KontrolasController : Controller
    {
        private Model1 db = new Model1();

        // GET: Kontrolas
        public async Task<ActionResult> Index()
        {
            return View(await db.Kontrolas.ToListAsync());
        }

        // GET: Kontrolas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontrola kontrola = await db.Kontrolas.FindAsync(id);
            if (kontrola == null)
            {
                return HttpNotFound();
            }
            return View(kontrola);
        }

        // GET: Kontrolas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kontrolas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDkon,kontrola1")] Kontrola kontrola)
        {
            if (ModelState.IsValid)
            {
                db.Kontrolas.Add(kontrola);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(kontrola);
        }

        // GET: Kontrolas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontrola kontrola = await db.Kontrolas.FindAsync(id);
            if (kontrola == null)
            {
                return HttpNotFound();
            }
            return View(kontrola);
        }

        // POST: Kontrolas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDkon,kontrola1")] Kontrola kontrola)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kontrola).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(kontrola);
        }

        // GET: Kontrolas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontrola kontrola = await db.Kontrolas.FindAsync(id);
            if (kontrola == null)
            {
                return HttpNotFound();
            }
            return View(kontrola);
        }

        // POST: Kontrolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Kontrola kontrola = await db.Kontrolas.FindAsync(id);
            db.Kontrolas.Remove(kontrola);
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
