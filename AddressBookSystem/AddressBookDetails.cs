using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class AddressBookDetails : IAddressBook
    {
        string nameOfAddressBook;
        const string ADD_CONTACT = "add";
        const string UPDATE_CONTACT = "update";
        const string SEARCH_CONTACT = "search";
        const string REMOVE_CONTACT = "remove";
        const string GET_ALL_CONTACTS = "view";
        public Dictionary<string, AddressBook> addressBookList = new Dictionary<string, AddressBook>();
        /// Gets the address book.
        private AddressBook GetAddressBook()
        {
            Console.WriteLine("\nEnter name of Address Book to be accessed or to be added");
            nameOfAddressBook = Console.ReadLine();

            // search for address book in dictionary
            if (addressBookList.ContainsKey(nameOfAddressBook))
            {
                Console.WriteLine("\nAddressBook Identified");       
                return addressBookList[nameOfAddressBook];
            }

            // Offer to create a address book if not found in dictionary
            Console.WriteLine("\nAddress book not found. Type y to create a new address book or E to abort");

            // If user want to create a new address book
            if ((Console.ReadLine().ToLower()) == "y")
            {
                AddressBook addressBook = new AddressBook(nameOfAddressBook);
                addressBookList.Add(nameOfAddressBook, addressBook);
                Console.WriteLine("\nNew AddressBook Created");
                return addressBookList[nameOfAddressBook];
            }
            // If User want to abort the operation 
            else
            {
                Console.WriteLine("\nAction Aborted");             
                return null;
            }
        }
        // Deletes the address book.
        public void DeleteAddressBook()
        {
            // Returns no record found if address book is empty
            if (addressBookList.Count == 0)
            {
                Console.WriteLine("No record found");
                return;
            }
            Console.WriteLine("\nEnter the name of address book to be deleted :");
            //search for address book with given name
            try
            {
                addressBookList.Remove(Console.ReadLine());
                Console.WriteLine("Address book deleted successfully");
            }
            catch
            {
                Console.WriteLine("Address book not found");
            }
        }
        // Views all address books.
        public void ViewAllAddressBooks()
        {
            // Returns no record found if address book is empty
            if (addressBookList.Count == 0)
            {
                Console.WriteLine("No record found");
                return;
            }
            // Print the address book names available
            Console.WriteLine("\nThe namesof address books available are :");
            foreach (KeyValuePair<string, AddressBook> keyValuePair in addressBookList)
                Console.WriteLine(keyValuePair.Key);
        }
        /// Adds the or access address book.
        public void AddOrAccessAddressBook()
        {
            // To get the name of the addressbook
            AddressBook addressBook = GetAddressBook();

            // Returns no record found if address book is empty
            if (addressBook == null)
            {
                Console.WriteLine("Action aborted");
                return;
            }

            // select the action to be performed in address book   
            while (true)
            {
                Console.WriteLine("\nSelect from below to work on Address book {0}", addressBook.nameOfAddressBook);
                Console.WriteLine("\nType\n\nAdd - To add a contact" +
                                  "\nUpdate- To update a contact" +
                                  "\nView - To view all contacts" +
                                  "\nRemove - To remove a contact and " +
                                  "\nSearch- To search to get contact deatails\nE - To exit\n ");
                switch (Console.ReadLine().ToLower())
                {
                    case ADD_CONTACT:
                        addressBook.AddContact();
                        break;

                    case UPDATE_CONTACT:
                        addressBook.UpdateContact();
                        break;

                    case SEARCH_CONTACT:
                        addressBook.DisplayContactDetails();
                        break;

                    case REMOVE_CONTACT:
                        addressBook.RemoveContact();
                        break;

                    case GET_ALL_CONTACTS:
                        addressBook.GetAllContacts();
                        break;

                    default:
                        Console.WriteLine("\nInvalid option. Exiting address book");
                        return;
                }

                // Ask the user to continue in same address book or to exit
                Console.WriteLine("\nType y to continue in same address Book or any other key to exit");

                // If not equal to y  then exit
                if (!(Console.ReadLine().ToLower() == "y"))
                {              
                    return;
                }
            }
        }
    }
}
