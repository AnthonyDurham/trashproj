using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollectorProj.Data;
using TrashCollectorProj.Models;

namespace TrashCollectorProj.Controllers
{
    public class CustomersController : Controller

    {
        private readonly ApplicationDbContext _context;

        public  CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customerLoggedIn =     
            //var applicationDbContext = _context.Customers.Include(c => c.IdentityUser);
            //return View(applicationDbContext.ToList());
        }

            // GET: Customers/Details/5
            public ActionResult Details(int? id)
            {
            if (id == null)
            {
                return NotFound();
            }
            var customer =  _context.Customers
               .Include(c => c.IdentityUser)
               .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)

                return View();
            }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
          
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Customer customer = new Customer();
                customer.CustomerId = Convert.ToInt32(collection["CustomerId"]);
                customer.Name = collection["Name"];
                customer.Address = Convert.ToInt32(collection["Adress"]);
                customer.City = collection["City"];
                customer.State = collection["State"];
                customer.Zip = Convert.ToInt32(collection["Zip"]);
                customer.pickupDay = collection["pickupDay"];
                customer.startTerminationDay = collection["startTerminationDay"];
                customer.endTerminationDay = collection["endTerminationDay"];

                _context.Add(customer);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
                return View(customer);
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            
            return View();
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            if (id != Customer==CustomerId)
            {
                return NotFound();
            }
            try
            {
                _context.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch 
            
                return View(customer);
            }

        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers
                .Include(c => c.IdentityUser)
                .FirstOrDefault(c => c.CustomerId == id);
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]  public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var customer = _context.Customers.Find(id);
                  _context.Customers.Remove(customer);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}