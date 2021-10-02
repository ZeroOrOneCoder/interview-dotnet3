using Newtonsoft.Json;
using System.Collections.Generic;

namespace GroceryStoreAPI.Models
{
    public class CustomerList
    {
        public CustomerList()
        {
            Customers = new List<Customer>();
        }
        [JsonProperty("customers")]
        public List<Customer> Customers { get; set; }
    }
}
