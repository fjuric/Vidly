using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var viewCustomerModel = new ListCustomerViewModel();
            viewCustomerModel.GetCustomers();
            return View(viewCustomerModel);
        }
        public ActionResult Details(int id)
        {
            var viewCustomerModel = new ListCustomerViewModel();
            Customer customer = new Customer();
            viewCustomerModel.GetCustomers();
            if (viewCustomerModel == null)
                return HttpNotFound();
            foreach (Customer c in viewCustomerModel.Customers)
            {
                if (c.Id == id)
                    customer = c;
            }
            return View(customer);
        }
    }
}