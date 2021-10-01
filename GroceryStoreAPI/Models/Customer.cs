using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class customer
    {
        public customer(int cid, string cname)
        {
            id = cid;
            name = cname;
        }
        public int id { get; set; }
        public string name { get; set; }
    }
}
