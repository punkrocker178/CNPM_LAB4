using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab3_CNPM;
using Lab3_CNPM.Models;

namespace Lab3_CNPM.Controllers
{
    public class LaptopsController : Controller
    {
        private LaptopDAO dao = new LaptopDAO(new LaptopContext());

        // GET: Laptops
        public ActionResult Index()
        {
            return View(dao.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Laptop model)
        {
            dao.AddLaptop(model);
            return RedirectToAction("Index");
        }

        public ActionResult CreateLaptop()
        {
            if (dao.GetLaptopCount() > 0)
            {
                return RedirectToAction("Index");
            }
            dao.AddLaptop(new Laptop("L001", "Macbook Air", 999, "i5", 8, 128));
            dao.AddLaptop(new Laptop("L002", "Macbook Air", 1299, "i5", 8, 256));
            dao.AddLaptop(new Laptop("L003", "Macbook Air", 1499, "i7", 16, 512));
            dao.AddLaptop(new Laptop("L004", "Macbook Pro 13\"", 1299, "i5", 8, 256));
            dao.AddLaptop(new Laptop("L005", "Macbook Pro 13\"", 1699, "i5", 8, 512));
            dao.AddLaptop(new Laptop("L006", "Macbook Pro 13\"", 1899, "i7", 16, 256));
            dao.AddLaptop(new Laptop("L007", "Macbook Pro 13\"", 2199, "i7", 16, 512));
            dao.AddLaptop(new Laptop("L008", "Macbook Pro 15\"", 2199, "i5", 16, 256));
            dao.AddLaptop(new Laptop("L009", "Macbook Pro 15\"", 2399, "i5", 16, 512));
            dao.AddLaptop(new Laptop("L0010", "Macbook Pro 15\"", 2499, "i7", 16, 512));
            dao.AddLaptop(new Laptop("L011", "Macbook Pro 15\"", 2699, "i7", 32, 1024));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dao.DeleteLaptop(dao.GetLaptop(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = dao.GetLaptop(id);
            return View("Update", laptop);
        }

        [HttpPost]
        public ActionResult Update(Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                dao.UpdateLaptop(laptop);
                return RedirectToAction("Index");
            }
            return View(laptop);
        }

    }
}
