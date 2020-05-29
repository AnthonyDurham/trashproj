using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TrashCollectorProj.Data;
using TrashCollectorProj.Models;

namespace TrashCollectorProj.Controllers
{[Authorize(Roles ="cstomer")]
    public class CustomersController : Controller

    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Customers
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerLoggedIn = _context.Customers.Where(c => c.IDentityUSerId == userId).SingleOrDefault();
            if (customerLoggedIn == null)
            {
                return RedirectToAction("Create");
            }

            return View(customerLoggedIn);


        }

        // GET: Customers/Details/5
        public ActionResult Details(int? IDentityUSerId)
        {
            if (IDentityUSerId == null)
            {
                return NotFound();
            }

            var customer = _context.Customers
               .Include(c => c.IdentityUser)
               .FirstOrDefaultAsync(m => m.CustomerId == IDentityUSerId);
            if (customer == null)
            {
                return NotFound();

            }
            return View();
        }


        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewData["IDentityUSerId"] = new SelectList(_context.Users, "Id", "Id");
            return View();

        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IDentityUSerId = userId;

                _context.Add(customer);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["IDentityUSerId"] = new SelectList(_context.Users, "Id", "Id", _context.ContextId);
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {

            var customer = _context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
            return View(customer);
        }




        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            return View();
        }


    }

}