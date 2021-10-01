using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.Services
{
    public interface ICustomerService
    {
        public List<customer> GetCustomers();

        public List<customer> GetCustomerById(int id);
       
        public List<customer> AddCustomer(string custName);

        public bool UpdateCustomer(int id, string name);

        //public bool DeleteCustomer(int id);

        public bool DeleteCustomerById(int id);

    }
}
