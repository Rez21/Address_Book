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
            string firstName;
            string lastName;
            string address;
            string city;
            string state;
            string zip;
            string phoneNumber;
            string email;
            Console.WriteLine("Welcome to Address Book Program");

            AddressBook addressBook = new AddressBook();

            Console.WriteLine("Enter the first name of contact");
            firstName = Console.ReadLine();

            Console.WriteLine("Enter the last name of contact");
            lastName = Console.ReadLine();

            Console.WriteLine("Enter the address of contact");
            address = Console.ReadLine();

            Console.WriteLine("Enter the city name of contact");
            city = Console.ReadLine();

            Console.WriteLine("Enter the state name of contact");
            state = Console.ReadLine();

            Console.WriteLine("Enter the zip of locality of contact");
            zip = Console.ReadLine();

            Console.WriteLine("Enter the phone number of contact");
            phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter the email of contact");
            email = Console.ReadLine();

            // Adding contact into address book
            addressBook.AddContact(firstName, lastName, address, city, state, zip, phoneNumber, email);

            // Searching phone Number by contact name
            Console.WriteLine("Enter the name of Contact to get Phone number");
            addressBook.DisplayPhoneNumber(Console.ReadLine());

        }
    }
}
