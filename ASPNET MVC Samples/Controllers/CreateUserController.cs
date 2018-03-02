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
    public class CreateUserController : Controller
    {
        private SHELLMVCEntities db = new SHELLMVCEntities();

        // GET: /CreateUser/
        public async Task<ActionResult> Index()
        {
            var userlogins = db.UserLogins.Include(u => u.UserType).Include(u => u.StationName);
            return View(await userlogins.ToListAsync());
        }

        // GET: /CreateUser/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogin userlogin = await db.UserLogins.FindAsync(id);
            if (userlogin == null)
            {
                return HttpNotFound();
            }
            return View(userlogin);
        }

        // GET: /CreateUser/Create
        public ActionResult Create()
        {
            ViewBag.Type = new SelectList(db.UserTypes, "Type", "Type");
            ViewBag.Station = new SelectList(db.StationNames, "StationName1", "StationName1");
            return View();
        }

        // POST: /CreateUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,User,Password,Type,Station")] UserLogin userlogin)
        {
            if (ModelState.IsValid)
            {
                var IsUserExist = (from n in db.UserLogins where n.User == userlogin.User  select n).Any();
                if (IsUserExist)
                {
                             return Content("<script language='javascript' type='text/javascript'>alert('Sorry User Already Exist!');</script>");
   
                }
                else
                {
                    db.UserLogins.Add(userlogin);
                    await db.SaveChangesAsync();
                    Session["UserType"] = userlogin.Type;
                    Session["UserStation"] = userlogin.Station;
                    return RedirectToAction("Index", "ViewData");
                }

            }

            ViewBag.Type = new SelectList(db.UserTypes, "Type", "Type", userlogin.Type);
            ViewBag.Station = new SelectList(db.StationNames, "StationName1", "StationName1", userlogin.Station);
            return View(userlogin);
        }

        // GET: /CreateUser/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogin userlogin = await db.UserLogins.FindAsync(id);
            if (userlogin == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type = new SelectList(db.UserTypes, "Type", "Type", userlogin.Type);
            ViewBag.Station = new SelectList(db.StationNames, "StationName1", "StationName1", userlogin.Station);
            return View(userlogin);
        }

        // POST: /CreateUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,User,Password,Type,Station")] UserLogin userlogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userlogin).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Type = new SelectList(db.UserTypes, "Type", "Type", userlogin.Type);
            ViewBag.Station = new SelectList(db.StationNames, "StationName1", "StationName1", userlogin.Station);
            return View(userlogin);
        }

        // GET: /CreateUser/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogin userlogin = await db.UserLogins.FindAsync(id);
            if (userlogin == null)
            {
                return HttpNotFound();
            }
            return View(userlogin);
        }

        // POST: /CreateUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserLogin userlogin = await db.UserLogins.FindAsync(id);
            db.UserLogins.Remove(userlogin);
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
