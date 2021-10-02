using GroceryStoreAPI.Data;
using GroceryStoreAPI.Models;
using System.Collections.Generic;

namespace GroceryStoreAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDataAccess _acessJson;
        public CustomerService(IDataAccess dataAccess)
        {
            _acessJson = dataAccess;
        }

        public Customer GetCustomerById(int id)
        {
            return _acessJson.GetItemById(id);
        }

        public List<Customer> GetCustomers()
        {
            return _acessJson.GetAll();
        }

        public Customer AddCustomer(string custName)
        {
            return _acessJson.AddItem(custName);
        }

        public bool UpdateCustomer(int id, string name)
        {
            Customer c = new Customer(id, name);
            return _acessJson.UpdateItem(c);
        }

        //public bool DeleteCustomer(Customer c)
        //{
        //    return aj.DeleteItem(c);
        //}

        public bool DeleteCustomerById(int id)
        {
            return _acessJson.DeleteItemById(id);
        }
    }
}
