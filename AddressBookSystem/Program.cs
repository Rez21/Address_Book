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
        void AddOrAccessAddressBook();
        void ViewAllAddressBooks();
        void DeleteAddressBook();
    }

    public class Program
    {
        public const string TO_ADD_OR_ACCESS = "add";
        public const string TO_VIEW_ALL_ADDRESSBOOKS = "view";
        public const string TO_DELETE_ADDRESS_BOOK = "delete";
        public const string SEARCH_PERSON_IN_CITY = "city";
        public const string SEARCH_PERSON_IN_STATE = "state";
        public const string VIEW_ALL_IN_CITY = "vcity";
        public const string VIEW_ALL_IN_STATE = "vstate";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book Program");
            AddressBookDetails addressBookDetails = new AddressBookDetails();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nType to select address book" +
                                  "\nAdd - To add or access address book" +
                                  "\nview - To view all names of address books" +
                                  "\nDelete - To delete Address book" +
                                  "\nCity - To search contact in a city" +
                                  "\nState - To search contact in a state" +
                                  "\nVCity - To view all contacts in a city" +
                                  "\nVState - To view all contacts in a state" +
                                  "\nE - To exit");
                switch (Console.ReadLine().ToLower())
                {
                    // To add or access new Address book
                    case TO_ADD_OR_ACCESS:
                        addressBookDetails.AddOrAccessAddressBook();
                        break;
                    // To view all address book names
                    case TO_VIEW_ALL_ADDRESSBOOKS:
                        addressBookDetails.ViewAllAddressBooks();
                        break;
                    // To delete an address book
                    case TO_DELETE_ADDRESS_BOOK:
                        addressBookDetails.DeleteAddressBook();
                        break;
                    // To search for a person in a city
                    case SEARCH_PERSON_IN_CITY:
                        addressBookDetails.SearchInCity();
                        break;
                    // To search for a person in a state
                    case SEARCH_PERSON_IN_STATE:
                        addressBookDetails.SearchInState();
                        break;
                    // To view all contacts in a city
                    case VIEW_ALL_IN_CITY:
                        addressBookDetails.ViewAllByCity();
                        break;
                    // To view all contacts in a city
                    case VIEW_ALL_IN_STATE:
                        addressBookDetails.ViewAllByState();
                        break;
                    default:
                        Console.WriteLine("User exited application");
                        flag = false;
                        return;
                }
            }
        }
    }
}
