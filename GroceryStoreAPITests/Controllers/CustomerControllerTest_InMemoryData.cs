using GroceryStoreAPI.Data;
using GroceryStoreAPI.Models;
using GroceryStoreAPI.Services;
using GroceryStoreAPITests.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace GroceryStoreAPI.Controllers.Tests
{
    [TestClass()]
    public class CustomerControllerTest_InMemoryData
    {
        private IConfiguration _config;
        private IDataAccess _imd;
        private ICustomerService _customerService;
        private ILogger _logger; //not testing the logging part at this stage

        public CustomerControllerTest_InMemoryData()
        {
            //Read config file
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);
            _config = builder.Build();
            
            _imd = new InMemoryData();
                
            _customerService = new CustomerService(_imd, _config);
            }

        [TestMethod()]
        public void GetTest_ReturnAllCustomers()
        {

            CustomerController uc = new CustomerController(_customerService, null);
            var result = uc.Get();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.GetType() == typeof(OkObjectResult));

            if (result != null && result.GetType() == typeof(OkObjectResult))
            {
                var result1 = result as OkObjectResult;
                Assert.IsTrue(((List<Customer>)result1.Value).Count >= 3); //Just a loose check here. The accurate total number checks while we run add/delete methods.
                //Assert.IsTrue(((List<Customer>)result1.Value).Count == 11);

            }

        }

        [TestMethod()]
        public void GetByIdTest_ReturnCustomer2()
        {

            CustomerController uc = new CustomerController(_customerService, null);
            var result = uc.GetById(2);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.GetType() == typeof(OkObjectResult));
            if (result != null)
            {
                var result1 = result as OkObjectResult;
                Assert.IsTrue(((Customer)result1.Value).id == 2);
            }

        }

        [TestMethod()]
        public void GetByIdTest_ShouldNotFind()
        {

            CustomerController uc = new CustomerController(_customerService, null);
            var result = uc.GetById(99);
            Assert.IsTrue(result.GetType() == typeof(NotFoundObjectResult));

        }

        [TestMethod()]
        public void AddTest_AddNewCustomer()
        {

            CustomerController uc = new CustomerController(_customerService, null);
            var result = uc.Add("Lisa");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.GetType() == typeof(CreatedResult));
            if (result != null)
            {
                var result1 = result as CreatedResult;
                Assert.IsTrue(result1.Location != null);
            }

        }

        [TestMethod()]
        public void UpdateTest_UpdateCustomer2()
        {

            CustomerController uc = new CustomerController(_customerService, null);
            var result = uc.Update(2, "Lilly");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.GetType() == typeof(AcceptedResult));
            if (result != null)
            {
                var result1 = result as AcceptedResult;
                Assert.IsTrue(result1.Location != null);
            }
        }

        [TestMethod()]
        public void UpdateTest_FailToUpdateNonExisingCustomer()
        {

            CustomerController uc = new CustomerController(_customerService, null);
            var result = uc.Update(53, "Unknown");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.GetType() == typeof(NotFoundObjectResult));
            if (result != null)
            {
                var result1 = result as NotFoundObjectResult;
                Assert.IsTrue((int)result1.Value == 53);
            }
        }

        [TestMethod()]
        public void DeleteTest_DeleteCustomer()
        {

            CustomerController uc = new CustomerController(_customerService, null);
            var result = uc.Delete(4);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.GetType() == typeof(NoContentResult));

            //Verify that the customer doesn't exist
            var result1 = uc.GetById(4);
            Assert.IsTrue(result1.GetType() == typeof(NotFoundObjectResult));
        }

        [TestMethod()]
        public void DeleteTest_FailToDeleteNonExitingCustomer()
        {

            CustomerController uc = new CustomerController(_customerService, null);
            var result = uc.Delete(53);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.GetType() == typeof(NotFoundObjectResult));
            if (result != null)
            {
                var result1 = result as NotFoundObjectResult;
                Assert.IsTrue((int)result1.Value == 53);
            }
            //Verify that the customer doesn't exist
            var result2 = uc.GetById(53);
            Assert.IsTrue(result2.GetType() == typeof(NotFoundObjectResult));
        }
    }
}