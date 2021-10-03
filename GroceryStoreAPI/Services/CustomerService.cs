using GroceryStoreAPI.Data;
using GroceryStoreAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace GroceryStoreAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDataAccess _accessJson;
        private readonly IConfiguration _config;

        //private readonly IOptions<DataAccessSettings> _appSettings;
        //public CustomerService(IDataAccess dataAccess, IOptions<DataAccessSettings> appSettings)
        //{
        //    _appSettings = appSettings;
        //    _accessJson = dataAccess;
        //    _accessJson.Connection = appSettings.Value.Connection;
        //}

        public CustomerService(IDataAccess dataAccess, IConfiguration config)
        {
            _config = config;
            _accessJson = dataAccess;
            _accessJson.Connection = _config.GetValue<string>("DataAcessSettings:Connection");
        }

        public Customer GetCustomerById(int id)
        {
            return _accessJson.GetItemById(id);
        }

        public List<Customer> GetCustomers()
        {
            return _accessJson.GetAll();
        }

        public Customer AddCustomer(string custName)
        {
            return _accessJson.AddItem(custName);
        }

        public bool UpdateCustomer(int id, string name)
        {
            Customer c = new Customer(id, name);
            return _accessJson.UpdateItem(c);
        }

        //public bool DeleteCustomer(Customer c)
        //{
        //    return aj.DeleteItem(c);
        //}

        public bool DeleteCustomerById(int id)
        {
            return _accessJson.DeleteItemById(id);
        }
    }
}
