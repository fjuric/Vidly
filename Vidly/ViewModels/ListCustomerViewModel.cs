using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
namespace Vidly.ViewModels
{
    public class ListCustomerViewModel
    {
        public List<Customer> Customers { get; set; }

        internal List<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Filip"},
                new Customer {Id = 2, Name = "Kata"},
                new Customer {Id = 3, Name = "Anka"}
            };
            return Customers = customers;
        }
    }
}