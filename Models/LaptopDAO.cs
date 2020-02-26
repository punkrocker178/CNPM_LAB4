using Lab3_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_CNPM
{
    public class LaptopDAO
    {
        private LaptopContext db;
        public LaptopDAO(LaptopContext context)
        {
            this.db = context;
        }

        public IEnumerable<Laptop> GetAll()
        {
            return db.Laptops;
        }

        public bool AddLaptop(Laptop lap)
        {
            try
            {
                db.Laptops.Add(lap);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // assume that the 'lap' object is previously retrived from database via LaptopContext
        public bool UpdateLaptop(Laptop lap)
        {
            try
            {
                db.Entry(lap).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteLaptop(Laptop lap)
        {
            try
            {
                db.Laptops.Remove(lap);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Laptop> GetAllLaptops()
        {
            return db.Laptops; // this is lazy loading. The data is only loaded when we loop over it
        }

        // get all laptops by cpu name
        public List<Laptop> GetLaptopByCPU(String cpu)
        {
            return db.Laptops.Where(laptop => laptop.CPU == cpu).ToList<Laptop>();
        }

        public IEnumerable<Laptop> GetLaptopHasRamEqualOrGreaterThan(int ram)
        {
            var data = from laptop in db.Laptops
                       where laptop.RAM >= ram
                       select laptop;

            return data;
        }

        public int GetLaptopCount()
        {
            return (from lap in db.Laptops
                    select lap).Count();
        }

        public Laptop GetLaptop(string id)
        {
            return db.Laptops.Find(id);
        }
    }
}