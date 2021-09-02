using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineBar_Balraj.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int WineID { get; set; }
        public int WaiterID { get; set; }
        public Wine Wine { get; set; }
        public Waiter Waiter { get; set; }
    }
}
