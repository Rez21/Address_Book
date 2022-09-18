using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class AddressBookDetails
    {
        string nameOfAddressBook;
        public Dictionary<string, AddressBook> addressBookList = new Dictionary<string, AddressBook>();
        public AddressBookDetails()
        {

        }
        internal AddressBook GetAddressBook()
        {
            Console.WriteLine("\nEnter name of Address Book to be accessed or to be added");
            nameOfAddressBook = Console.ReadLine();

            if (addressBookList.ContainsKey(nameOfAddressBook))
            {
                Console.WriteLine("\nAddressBook Identified");
                return addressBookList[nameOfAddressBook];
            }
            else
            {
                Console.WriteLine("\nAddress book not found. Type y to create a new address book or E to abort");
                if ((Console.ReadLine().ToLower()) == "y")
                {
                    AddressBook addressBook = new AddressBook(nameOfAddressBook);
                    addressBookList.Add(nameOfAddressBook, addressBook);
                    Console.WriteLine("\nNew AddressBook Created");
                    return addressBookList[nameOfAddressBook];
                }
                else
                    Console.WriteLine("\nAction Aborted");
                return null;

            }
        }
    }
}
