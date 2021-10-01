using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Helpers
{
    public class HttpResponseException
    {
        public int Status { get; set; } = 500;
        public object Value { get; set; }
    }
}
