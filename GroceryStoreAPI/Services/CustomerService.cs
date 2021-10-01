using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.Data;

namespace GroceryStoreAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AccessJSON aj;
        public CustomerService(AccessJSON accessJson)
        {
            aj = accessJson;
        }

        public List<customer> GetCustomerById(int id)
        {
            return aj.GetItemById(id);
        }

        public List<customer> GetCustomers()
        {
            return aj.GetAll();
        }

        public List<customer> AddCustomer(string custName)
        {
            return aj.AddItem(custName);
        }

        public bool UpdateCustomer(int id, string name)
        {
            customer c = new customer(id, name);
            return aj.UpdateItem(c);
        }

        //public bool DeleteCustomer(Customer c)
        //{
        //    return aj.DeleteItem(c);
        //}

        public bool DeleteCustomerById(int id)
        {
            return aj.DeleteItemById(id);
        }
    }
}
