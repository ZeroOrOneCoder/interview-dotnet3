using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GroceryStoreAPI.Models
{
    public class Customer
    {
        public Customer(int cid, string cname)
        {
            id = cid;
            name = cname;
        }
        
        [JsonProperty("id")]
        public int id { get; set; }

        [Required]
        [JsonRequired]
        [JsonProperty("name")]
        public string name { get; set; }
    }
}
