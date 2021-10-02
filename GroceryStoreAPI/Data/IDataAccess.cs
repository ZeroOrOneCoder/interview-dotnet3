using GroceryStoreAPI.Models;
using System.Collections.Generic;

namespace GroceryStoreAPI.Data
{
    public interface IDataAccess
    {
        public string Connection { set; }
        public List<Customer> GetAll();

        public Customer GetItemById(int id);

        public bool UpdateItem(Customer customer);

        public bool DeleteItemById(int id);

        public Customer AddItem(string custName);
    }
}
