using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineBar_Balraj.Models
{
    public class Wine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
