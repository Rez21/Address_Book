using AddressBookSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    // Interface created for abstraction and easy access for user
    public interface IAddressBook
    {
        void DisplayContactDetails();
        void AddContact();
        public void UpdateContact();
        void RemoveContact();
    }
    class Program
    {
        const string addContact = "add";
        const string updateContact = "update";
        const string searchContact = "search";
        const string removeContact = "remove";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book Program");
            AddressBookDetails addressBookDetails = new AddressBookDetails();
            bool flag = true;
            while (flag)
            {
                AddressBook addressBook = addressBookDetails.GetAddressBook();
                if (addressBook != null)
                {
                    Console.WriteLine("\nSelect from below to work on Address book {0}", addressBook.nameOfAddressBook);
                    Console.WriteLine("\nType\n\nAdd - To add a contact \nUpdate- To update a contact\nRemove - To remove a contact and \nSearch- To search to get contact deatails\n");

                    switch (Console.ReadLine().ToLower())
                    {
                        case addContact:
                            addressBook.AddContact();
                            break;
                        case updateContact:
                            addressBook.UpdateContact();
                            break;
                        case searchContact:
                            addressBook.DisplayContactDetails();
                            break;
                        case removeContact:
                            addressBook.RemoveContact();
                            break;

                        default:
                            flag = false;
                            Console.WriteLine("\nInvalid option. Try again");
                            Console.WriteLine("\nEnter any key to exit");
                            break;
                    }
                }
                else
                    Console.WriteLine("\nAddress Book not found");
            }
            Console.ReadKey();
        }
    }
}