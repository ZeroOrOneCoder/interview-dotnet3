using GroceryStoreAPI.Models;
using GroceryStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger _logger;
        public CustomerController(ICustomerService icf, ILogger<CustomerController> logger)
        {
            _customerService = icf;
            _logger = logger;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            //Test
            //throw new Exception("Test Exception Handling.");

            List<Customer> items = _customerService.GetCustomers();
            if (items == null || items.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(items);
            }

        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Customer item = _customerService.GetCustomerById(id);
            if (item == null)
            {
                return NotFound(id);
            }
            else
            {
                return Ok(item);
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        //public IActionResult Add([FromBody] string name)
        public IActionResult Add([FromBody] Customer customer)

        {
            _logger.LogInformation($"New customer {customer.name} to be added.");

            Customer item = _customerService.AddCustomer(customer.name);
            if (item != null)
            {
                string relativePath = string.Format("/api/customer/{0}", item.id);
                return Created(new Uri(relativePath, UriKind.Relative), item.id);
            }
            else
            {
                return NotFound(customer.name);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody] string name)
        public IActionResult Update(int id, [FromBody] Customer customer)
        {
            _logger.LogInformation($"New customer {customer.id} and {customer.name} to be added.");

            if (id != customer.id)
            {
                return BadRequest("Mismatched customer Id.");
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_customerService.UpdateCustomer(customer))
            {
                string relativePath = string.Format("/api/customer/{0}", customer.id);
                return Accepted(new Uri(relativePath, UriKind.Relative), customer.name);
            }
            else
            {
                return NotFound(customer.id);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_customerService.DeleteCustomerById(id))
            {
                return NoContent();
            }
            else
            {
                return NotFound(id);
            }
        }
    }
}
