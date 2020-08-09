using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var viewCustomerModel = _context.Customers.Include(c => c.MembershipType).ToList();
            //var viewCustomerModel = new ListCustomerViewModel();
            //viewCustomerModel.GetCustomers();
            return View(viewCustomerModel);
        }
        public ActionResult Details(int id)
        {
            var viewCustomerModel = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (viewCustomerModel == null)
                return HttpNotFound();
            /*var viewCustomerModel = new ListCustomerViewModel();
            Customer customer = new Customer();
            viewCustomerModel.GetCustomers();
            if (viewCustomerModel == null)
                return HttpNotFound();
            foreach (Customer c in viewCustomerModel.Customers)
            {
                if (c.Id == id)
                    customer = c;
            }*/
            return View(viewCustomerModel);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}