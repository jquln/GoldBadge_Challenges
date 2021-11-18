using _00_JunkYard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_JunkYard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dictionary is a key/value pair type.
            // Think of this as an 'actual' dictionary
            // If i look up the word 'apple', which is a key
            // then the DEFINITION would be "the round fruit of a tree of the rose family,
            // which typically has thin red or green skin and crisp flesh.
            // Many varieties have been developed as dessert or cooking fruit or for making cider."
            // the DEFINITION is the value.

            //making a dictionary
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            //I want my key to be "apple" and my value to be the definition
            dictionary.Add("Apple", "the round fruit of a tree of the rose family, which typically has thin red or green skin and crisp flesh.Many varieties have been developed as dessert or cooking fruit or for making cider.");

            dictionary.Add("Orange", "a round juicy citrus fruit with a tough bright reddish-yellow rind");

            dictionary.Add("Banana", "a long curved fruit which grows in clusters and has soft pulpy flesh and yellow skin when ripe");


            // Dictionary is a collection. So, to get to the values you need to loop through the collection
            //this is the key/value pair approach..
            //if you hover over var -> keyValuePair<TKey, TValue>
            //is that fruit is a keyValuePair type
            foreach (var fruit in dictionary)
            {
                Console.WriteLine($"{fruit.Key}\n" +
                    $"{fruit.Value}");
                Console.WriteLine("---------------------------------\n");
            }
            Console.WriteLine("-------------------dictionary.Keys----------------------");
            //Now we can constring our loop
            //I can only see the key value
            //hover over var and you should see string
            foreach (var fruit in dictionary.Keys)
            {
                Console.WriteLine(fruit); // Should only get the names of the fruit b/c the names are the key
            }

            Console.WriteLine("-------------------dictionary.Values----------------------");
            //I can only see the value
            //Hover over var and you should see string
            //but fruit is now just the definition
            foreach (var fruit in dictionary.Values)
            {
                Console.WriteLine(fruit);
            }

            Console.WriteLine("-------------------What if things go WRONG!!!----------------------");

            //SO, you cannot have two items with the same key in a dictionary!!!!!!!
            //Example: This will blow up!!!

            Console.WriteLine("------------Actually putting things to use...---------------------");
            // Now we'll use a customer
            Dictionary<int, Customer> _customerDB = new Dictionary<int, Customer>();
            int _count = 0;
            //lets add customers SEEDED DATA
            Customer customer = new Customer("Jacquelyn", "Mitchell",
                                                new List<string>
                                                {
                                                    "Dress",
                                                    "Vodka",
                                                    "Forks"
                                                });

            Customer customer1 = new Customer("Terry", "Brown",
                                              new List<string>
                                              {
                                                    "Ps5",
                                                    "Hamburger",
                                                    "Forks"

                                              });
            Customer customer2 = new Customer("Justin", "Case",
                                              new List<string>
                                              {
                                                    "Tacos",
                                                    "Hamburger",
                                                    "Plates"
                                              });

            bool AddCustomer(Customer customerObj)
            {
                if (customerObj == null)
                {
                    return false;
                }
                else
                {
                    _count++;
                    customerObj.ID = _count;
                    //now we need to add this customer to the _customerDB (this is a dictionary)
                    _customerDB.Add(customerObj.ID, customerObj);
                    return true;
                }
            }

            AddCustomer(customer);
            AddCustomer(customer1);
            AddCustomer(customer2);

            foreach (var c in _customerDB)
            {
                Console.WriteLine(c.Key);
                Console.WriteLine(c.Value.FirstName);
            }

            //I want one customer
            Customer GiveMeACustomer(int key)
            {
                foreach (var cust in _customerDB)
                {
                    if (cust.Key == key)
                    {
                        return cust.Value;
                    }
                }
                return null;
            }

            Customer jaq = GiveMeACustomer(1);

            Console.WriteLine($"{jaq.FirstName} {jaq.LastName}");
            //--------------------------------------------------------

            // What if i wanted to remove an item from a customers list?
            // First i have to find the customer
            bool RemoveCustomerItem(int customerKey, string itemToRemove)
            {
                Customer retrievedCustomer = GiveMeACustomer(customerKey);
                if (retrievedCustomer != null)
                {
                    foreach (var itemInCart in retrievedCustomer.ItemsInCart)
                    {
                        if (itemInCart == itemToRemove)
                        {
                            retrievedCustomer.ItemsInCart.Remove(itemInCart);
                            return true;
                        }
                    }
                    return false;
                }
                return false;

            }

            bool success = RemoveCustomerItem(3, "Hamburger");
            if (success)
            {
                Console.WriteLine("We removed the item.");
                foreach (var item in customer2.ItemsInCart)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("FAIL.");
            }

            bool AddCustomerItem(int customerKey, string itemToAdd)
            {
                Customer retrievedCustomer = GiveMeACustomer(customerKey);
                if (retrievedCustomer != null)
                {
                    retrievedCustomer.ItemsInCart.Add(itemToAdd);
                    return true;
                }
                return false;
            }

            bool itWorks = AddCustomerItem(1, "Tacos");
            if (itWorks)
            {
                Console.WriteLine("WORKS");
                foreach (var item in customer.ItemsInCart)
                {
                    Console.WriteLine(item);
                }
            }


            Console.ReadKey();





        }
    }
}
