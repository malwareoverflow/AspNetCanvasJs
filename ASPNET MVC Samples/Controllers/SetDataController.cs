using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNET_MVC_Samples;

namespace ASPNET_MVC_Samples.Controllers
{
    public class SetDataController : Controller
    {
        private SHELLMVCEntities db = new SHELLMVCEntities();

        // GET: /SetData/
        public async Task<ActionResult> Index()
        {
            if (!string.IsNullOrEmpty(Session["UserType"] as string))
            {
                return View(await db.SETDATAs.ToListAsync());
            }
            return RedirectToAction("Create", "CreateUser");
        }

        // GET: /SetData/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SETDATA setdata = await db.SETDATAs.FindAsync(id);
            if (setdata == null)
            {
                return HttpNotFound();
            }
            return View(setdata);
        }

        // GET: /SetData/Create
        public ActionResult Create()
        {
            if (!string.IsNullOrEmpty(Session["UserType"] as string))
            {
                return View();
            }
            return RedirectToAction("Create", "CreateUser");
        }

        // POST: /SetData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Datetime,SetTempreture,SetHumidity,Station")] SETDATA setdata)
        {
            if (ModelState.IsValid)
            {
                setdata.Datetime = DateTime.Now;
                db.SETDATAs.Add(setdata);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(setdata);
        }

        // GET: /SetData/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SETDATA setdata = await db.SETDATAs.FindAsync(id);
            if (setdata == null)
            {
                return HttpNotFound();
            }
            return View(setdata);
        }

        // POST: /SetData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Datetime,SetTempreture,SetHumidity,Station")] SETDATA setdata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setdata).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(setdata);
        }

        // GET: /SetData/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SETDATA setdata = await db.SETDATAs.FindAsync(id);
            if (setdata == null)
            {
                return HttpNotFound();
            }
            return View(setdata);
        }

        // POST: /SetData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SETDATA setdata = await db.SETDATAs.FindAsync(id);
            db.SETDATAs.Remove(setdata);
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
