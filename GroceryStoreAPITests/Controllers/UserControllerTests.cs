using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Services;
using GroceryStoreAPI.Data;
using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStoreAPI.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        private static AccessJSON aj = new AccessJSON();
        private ICustomerService iCustomerService = new CustomerService(aj);

        [TestMethod()]
        public void GetTest()
        {
            List<customer> testCustomers = GetTestCustomers();
            CustomerController uc = new CustomerController(iCustomerService);
            var result = uc.Get() as List<customer>;
            Assert.AreEqual(testCustomers.Count, result.Count);
        }       

        [TestMethod()]
        public void GetByIdTest()
        {
            List<customer> testCustomers = GetTestCustomers();

            CustomerController uc = new CustomerController(iCustomerService);
            var result = uc.GetById(3) as List<customer>;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
            Assert.AreEqual(testCustomers[2].name, result[2].name);
        }

        public void GetByIdTest_ShouldNotFind()
        {
            List<customer> testCustomers = GetTestCustomers();

            CustomerController uc = new CustomerController(iCustomerService);
            var result = uc.GetById(12) as List<customer>;

            Assert.IsTrue(result.Count == 0);
        }

        private List<customer> GetTestCustomers()
        {
            List<customer> testCustomers = new List<customer>();
            testCustomers.Add(new customer(1, "Bob"));
            testCustomers.Add(new customer(2, "Mary"));
            testCustomers.Add(new customer(3, "Joe"));
            return testCustomers;
        }
    }
}