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
    public class ViewDataController : Controller
    {
        private SHELLMVCEntities db = new SHELLMVCEntities();

        // GET: /ViewData/
        public async Task<ActionResult> Index()
        {
            if (!string.IsNullOrEmpty(Session["UserType"] as string))
            {
              string Type=  Session["UserType"].ToString();
              if (Type=="Admin")
              {
                  return View(await db.SETDATAs.ToListAsync());
              }
              string CurrentUserStation = Session["UserStation"].ToString();
              var Getspecificstation = from n in db.SETDATAs where n.Station == CurrentUserStation select n;
               
              return View(await Getspecificstation.ToListAsync());
            }
            return RedirectToAction("Create", "CreateUser");
        }

        // GET: /ViewData/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIEWDATA viewdata = await db.VIEWDATAs.FindAsync(id);
            if (viewdata == null)
            {
                return HttpNotFound();
            }
            return View(viewdata);
        }

        // GET: /ViewData/Create
        public ActionResult Create()
        {
            if (!string.IsNullOrEmpty(Session["UserType"] as string))
            {
                ViewBag.Station = new SelectList(db.StationNames, "StationName1", "StationName1");

                return View();
            }


            return RedirectToAction("Create", "CreateUser");
        }

        // POST: /ViewData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Datetime,Station,SetTempreture,SetHumidity")] SETDATA viewdata)
        {
            if (ModelState.IsValid)
            {
                viewdata.Datetime = DateTime.Now;
                db.SETDATAs.Add(viewdata);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(viewdata);
        }

        // GET: /ViewData/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (string.IsNullOrEmpty(Session["UserType"] as string))
            {
                return RedirectToAction("Create", "CreateUser");
            }
            SETDATA viewdata = await db.SETDATAs.FindAsync(id);
            if (viewdata == null)
            {
                return HttpNotFound();
            }
            if (!string.IsNullOrEmpty(Session["UserType"] as string))
            {
                return View(viewdata);
            }
            return RedirectToAction("Create", "CreateUser");
       
        }

        // POST: /ViewData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Datetime,Station,Tempreture,Humidity,SetTempreture,SetHumidity")] SETDATA viewdata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewdata).State = EntityState.Modified;
                await db.SaveChangesAsync();
                viewdata.Datetime = DateTime.Now;
                return RedirectToAction("Index");
            }
            return View(viewdata);
        }

        // GET: /ViewData/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIEWDATA viewdata = await db.VIEWDATAs.FindAsync(id);
            if (viewdata == null)
            {
                return HttpNotFound();
            }
            return View(viewdata);
        }

        // POST: /ViewData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VIEWDATA viewdata = await db.VIEWDATAs.FindAsync(id);
            db.VIEWDATAs.Remove(viewdata);
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
