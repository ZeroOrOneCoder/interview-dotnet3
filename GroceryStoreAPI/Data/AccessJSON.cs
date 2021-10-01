using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.Models;
using Newtonsoft.Json;

namespace GroceryStoreAPI.Data
{
    public class AccessJSON
    {
        private static string filePath = "database.json";

        public AccessJSON()
        {
        }
        public AccessJSON(string FilePath)
        {
            filePath = FilePath;
        }

        private List<customer> ReadJsonFile()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string data = sr.ReadToEnd();
                //return JsonConvert.DeserializeObject<List<Customer>>(data);
                return JsonConvert.DeserializeObject<List<customer>>(data);

            }
        }

        private void WriteJsonFile(List<customer> customers)
        {
            string data = JsonConvert.SerializeObject(customers);
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.Write(data);
            }
        }

        public List<customer> GetAll()
        {
            List<customer> customers = ReadJsonFile();
            return customers;
        }

        public List<customer> GetItemById(int id)
        {
            List<customer> output = new List<customer>();
            List<customer> customers = ReadJsonFile();
            foreach (customer c in customers)
            {
                if (c.id == id)
                {
                    output.Add(c);
                    break;
                }
            }
            return output;
        }

        public bool UpdateItem(customer customer)
        {
            bool updated = false;
            List<customer> customers = ReadJsonFile();
            foreach (customer c in customers)
            {
                if (c.id == customer.id)
                {
                    c.name = customer.name;
                    break;
                }
            }
            string data = JsonConvert.SerializeObject(customers);
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.Write(data);
            }
            updated = true;
            return updated;
        }

        public bool DeleteItem(customer customer)
        {
            List<customer> customers = ReadJsonFile();
            foreach (customer c in customers)
            {
                if (c.id == customer.id)
                {
                    customers.Remove(c);
                    break;
                }
            }
            WriteJsonFile(customers);
            return true;
        }

        public bool DeleteItemById(int id)
        {
            List<customer> customers = ReadJsonFile();
            foreach (customer c in customers)
            {
                if (c.id == id)
                {
                    customers.Remove(c);
                    break;
                }
            }
            WriteJsonFile(customers);
            return true;
        }
        

        public List<customer> AddItem(string custName)
        {
            List<customer> output = new List<customer>();
            List<customer> customers = ReadJsonFile();
            CompareCustomer compareCust = new CompareCustomer();
            customers.Sort((IComparer<customer>)compareCust);
            int Id = customers[customers.Count - 1].id + 1;
            customer newCust = new customer(Id, custName);            
            output.Add(newCust);
            customers.Add(newCust);

            WriteJsonFile(customers);
            return output;
        }
        
        internal class CompareCustomer : IComparer<customer>
        {
            public int Compare([AllowNull] customer x, [AllowNull] customer y)
            {
                return x.id.CompareTo(y.id);
            }
        }
    }
}
