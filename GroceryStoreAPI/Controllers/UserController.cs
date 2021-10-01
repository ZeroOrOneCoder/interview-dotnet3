using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.Services;
using GroceryStoreAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService iCustomerService;

        public CustomerController(ICustomerService icf)
        {
            iCustomerService = icf;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(iCustomerService.GetCustomers());
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(iCustomerService.GetCustomerById(id));
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult AddNewCustomer([FromBody] string value)
        {
            List<customer> customers = iCustomerService.AddCustomer(value);
            if(customers.Count == 1)
            {
                string relativePath = @"/api/customer/{id}";
                return Created(new Uri(relativePath), customers[0]);
            }
            else
            {
                string msg = @"Failed to add customer with name {value}";
                string title = "Add a new customer Failed";
                return Problem(detail: msg, title);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] string value)
        {
            if (iCustomerService.UpdateCustomer(id, value))
            {
                string relativePath = @"/api/customer/{id}";
                return Accepted(new Uri(relativePath));
            }
            else
            {
                string msg = @"Failed to update customer with id {id}";
                string title = "Update Failed";
                return Problem(detail: msg, title);
             }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            if (iCustomerService.DeleteCustomerById(id))
            {
                return NoContent();
            }
            else
            {
                string msg = @"Failed to delete customer with id {id}";
                string title = "Delete Failed";
                return Problem(detail: msg, title);
            }
        }
    }
}
