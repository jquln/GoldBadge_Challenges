using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_JunkYard.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName {  get; set; } 
        public string LastName { get; set; }
        public List<string> ItemsInCart { get; set; }

        public Customer() {}

        public Customer(string firstName, string lastName, List<string> itemsInCart)
        {
            FirstName = firstName;
            LastName = lastName;
            ItemsInCart = itemsInCart;
        }
    }
}
