using ASYNC_CRUD.Models;
using ASYNC_CRUD.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASYNC_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private MyDB db = new MyDB();
        // GET: Employee
        public async Task<ActionResult> Index()
        {

            var model = await db.EMP.ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {

            return View(new Employee());
        }

        public async Task<ActionResult> Create(Employee _emp)
        {

            if (ModelState.IsValid)
            {
                db.EMP.Add(_emp);
                await db.SaveChangesAsync();
                return RedirectToAction("index");
            }

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee emp = await db.EMP.FindAsync(id);
            if (emp == null)
            {
                return HttpNotFound();
            }

            return View(emp);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(Employee _emp)
        {

            if (ModelState.IsValid)
            {
                db.Entry(_emp).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("index");

            }

            return View(_emp);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee emp = await db.EMP.FindAsync(id);
            if (emp == null)
            {
                return HttpNotFound();
            }

            return View(emp);

        }

         [HttpPost,ActionName("Delete")]
         [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmDelete(int? id)
        {
            Employee emp = await db.EMP.FindAsync(id);
            db.EMP.Remove(emp);
            await db.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {

            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Employee emp = await db.EMP.FindAsync(id);

            if (emp == null)
            {
                return HttpNotFound();
            }

            return View(emp);
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