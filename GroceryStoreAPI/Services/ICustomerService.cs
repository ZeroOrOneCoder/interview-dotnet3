﻿using GroceryStoreAPI.Models;
using System.Collections.Generic;

namespace GroceryStoreAPI.Services
{
    public interface ICustomerService
    {
        public List<Customer> GetCustomers();

        public Customer GetCustomerById(int id);

        public Customer AddCustomer(string custName);

        public bool UpdateCustomer(Customer customer);

        //public bool DeleteCustomer(int id);

        public bool DeleteCustomerById(int id);

    }
}
