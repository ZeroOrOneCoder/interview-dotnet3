using GroceryStoreAPI.Data;
using GroceryStoreAPI.Models;
using System.Collections.Generic;

namespace GroceryStoreAPITests.Controllers
{
    public class InMemoryData : IDataAccess
    {
        private List<Customer> testCustomers;
        private string connection;
        public InMemoryData()
        {
            testCustomers = new List<Customer>();
            
            testCustomers.Add(new Customer(1, "Bob"));
            testCustomers.Add(new Customer(2, "Mary"));
            testCustomers.Add(new Customer(3, "Joe"));
            testCustomers.Add(new Customer(4, "Jill"));
            testCustomers.Add(new Customer(5, "Kevin"));
        }

        public string Connection { set { connection = value; } }
        public List<Customer> GetAll()
        {
            return testCustomers;
        }

        public Customer GetItemById(int id)
        {
            Customer output = null;

            foreach (Customer c in testCustomers)
            {
                if (c.id == id)
                {
                    output = c;
                    break;
                }
            }
            return output;
        }

        public Customer AddItem(string custName)
        {
            int Id = testCustomers[testCustomers.Count - 1].id + 1;
            Customer output = new Customer(Id, custName);            

            testCustomers.Add(output);
            return output;
        }
        public bool UpdateItem(Customer customer)
        {
            bool updated = false;
            foreach (Customer c in testCustomers)
            {
                if (c.id == customer.id)
                {
                    c.name = customer.name;
                    updated = true;

                    break;
                }
            }

            return updated;
        }

        public bool DeleteItemById(int id)
        {
            bool Deleted = false;
            foreach (Customer c in testCustomers)
            {
                if (c.id == id)
                {
                    testCustomers.Remove(c);
                    Deleted = true;
                    break;
                }
            }

            return Deleted;
        }

    }
}
