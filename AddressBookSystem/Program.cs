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
        void AddContact(string firstName, string lastName, string address, string city, string state, string zip, string phonenumber, string email);
        void DisplayPhoneNumber(string Name);

    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");

            AddressBook addressBook = new AddressBook();

            // Adding contact into address book
            addressBook.AddContact("Prasad", "Ban", "Street NO: 39", "NewYork", "America", "123456", "1234567891", "sample@example.com");

            // Searching phone Number by contact name
            addressBook.DisplayPhoneNumber("Prasad");

        }
    }
}
