using GroceryStoreAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace GroceryStoreAPI.Data
{
    public class AccessJSON : IDataAccess
    {
        //TODO: this needs to be retrieved from appsetings.json
        private string connection = "database.json";

        public string Connection { set { connection = value; }}
       
        private CustomerList ReadJsonFile()
        {
            using (StreamReader sr = new StreamReader(connection))
            {
                string data = sr.ReadToEnd();
                //return JsonConvert.DeserializeObject<CustomerList>(data);
                return JsonConvert.DeserializeObject<CustomerList>(data);

            }
        }

        private void WriteJsonFile(CustomerList customers)
        {
            string data = JsonConvert.SerializeObject(customers);
            using (StreamWriter sw = new StreamWriter(connection, false))
            {
                sw.Write(data);
            }
        }

        public List<Customer> GetAll()
        {
            CustomerList cList = ReadJsonFile();
            return cList.Customers;
        }

        public Customer GetItemById(int id)
        {
            Customer output = null;
            CustomerList cList = ReadJsonFile();
            foreach (Customer c in cList.Customers)
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
            Customer output = null;
            CustomerList cList = ReadJsonFile();
            CompareCustomer compareCust = new CompareCustomer();
            cList.Customers.Sort((IComparer<Customer>)compareCust);
            int Id = cList.Customers[cList.Customers.Count - 1].id + 1;
            output = new Customer(Id, custName);

            cList.Customers.Add(output);

            WriteJsonFile(cList);
            return output;
        }
        public bool UpdateItem(Customer customer)
        {
            bool updated = false;
            CustomerList cList = ReadJsonFile();
            foreach (Customer c in cList.Customers)
            {
                if (c.id == customer.id)
                {
                    c.name = customer.name;
                    updated = true;

                    break;
                }
            }
            if (updated)
            {
                string data = JsonConvert.SerializeObject(cList);
                using (StreamWriter sw = new StreamWriter(connection, false))
                {
                    sw.Write(data);
                }
            }
            return updated;
        }

        public bool DeleteItemById(int id)
        {
            bool Deleted = false;
            CustomerList cList = ReadJsonFile();
            foreach (Customer c in cList.Customers)
            {
                if (c.id == id)
                {
                    cList.Customers.Remove(c);
                    Deleted = true;
                    break;
                }
            }
            if (Deleted)
            {
                WriteJsonFile(cList);
            }
            return Deleted;
        }

        internal class CompareCustomer : IComparer<Customer>
        {
            public int Compare([AllowNull] Customer x, [AllowNull] Customer y)
            {
                return x.id.CompareTo(y.id);
            }
        }
    }
}
