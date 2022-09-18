using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class AddressBook
    {
        public static Dictionary<string, ContactDetails> contactList = new Dictionary<string, ContactDetails>();
        const int UPDATE_FIRST_NAME = 1;
        const int UPDATE_LAST_NAME = 2;
        const int UPDATE_ADDRESS = 3;
        const int UPDATE_CITY = 4;
        const int UPDATE_STATE = 5;
        const int UPDATE_ZIP = 6;
        const int UPDATE_PHONE_NUMBER = 7;
        const int UPDATE_EMAIL = 8;

        // string name = " ";

        public void AddContact()
        {
            string firstName;
            string lastName;
            string address;
            string city;
            string state;
            string zip;
            string phoneNumber;
            string email;

            Console.WriteLine("\nEnter the first name of contact");
            firstName = Console.ReadLine();

            Console.WriteLine("\nEnter the last name of contact");
            lastName = Console.ReadLine();

            Console.WriteLine("\nEnter the address of contact");
            address = Console.ReadLine();

            Console.WriteLine("\nEnter the city name of contact");
            city = Console.ReadLine();

            Console.WriteLine("\nEnter the state name of contact");
            state = Console.ReadLine();

            Console.WriteLine("\nEnter the zip of locality of contact");
            zip = Console.ReadLine();

            Console.WriteLine("\nEnter the phone number of contact");
            phoneNumber = Console.ReadLine();

            Console.WriteLine("\nEnter the email of contact");
            email = Console.ReadLine();

            // Adding contact into address book
            ContactDetails addNewContact = new ContactDetails(firstName, lastName, address, city, state, zip, phoneNumber, email);
            try
            {
                contactList.Add(firstName + " " + lastName, addNewContact);
                Console.WriteLine("Contact Added");
            }
            catch
            {
                Console.WriteLine("The name of the contact already exits.");
            }


        }
        public void DisplayContactDetails()
        {
            Console.WriteLine("\nEnter the name of candidate to get Details");
            string name = Console.ReadLine().ToLower();
            DisplayContactDetails(name, "search");
        }
        private string SearchByName(string name)
        {
            int numOfConatctsWithNameSearched = 2;
            if (contactList.Count == 0)
            {
                Console.WriteLine("\nNo contacts saved");
                return null;
            }
            else
            {
                // Loop to find exact name being searched
                while (!contactList.ContainsKey(name))
                {
                    numOfConatctsWithNameSearched = 0;

                    foreach (KeyValuePair<string, ContactDetails> keyValuePair in contactList)
                    {
                        if ((keyValuePair.Key).Contains(name))
                        {
                            numOfConatctsWithNameSearched++; // num of contacts having search string
                            Console.WriteLine("\nname of contact is {0}", (keyValuePair.Value).firstName + " " + (keyValuePair.Value).lastName);
                        }

                    }
                    if (numOfConatctsWithNameSearched == 0)
                    {
                        Console.WriteLine("\nContact not found");
                        return null;
                    }
                    else
                    {
                        // Getting more accurate search
                        Console.WriteLine("\nInput the contact name as firstName lastName\n");
                        name = Console.ReadLine().ToLower();
                    }
                }
            }
            return name;
        }
        private void DisplayContactDetails(string name, string purpose)
        {
            name = SearchByName(name);
            // To display details of contact
            if (name == null)
                Console.WriteLine("Contact Not Found");
            else if (contactList.ContainsKey(name))
            {
                int serialNum = 1;
                Console.WriteLine("\nname of contact is {0}", name);
                Console.WriteLine("{0}- Firstname: {1}", serialNum++, contactList[name].firstName);
                Console.WriteLine("{0}- Lastname: {1}", serialNum++, contactList[name].lastName);
                Console.WriteLine("{0}- Address: {1}", serialNum++, contactList[name].address);
                Console.WriteLine("{0}- City: {1}", serialNum++, contactList[name].city);
                Console.WriteLine("{0}- State: {1}", serialNum++, contactList[name].state);
                Console.WriteLine("{0}- Zip code: {1}", serialNum++, contactList[name].zip);
                Console.WriteLine("{0}- Phone Number: {1}", serialNum++, contactList[name].phoneNumber);
                Console.WriteLine("{0}- Email ID: {1}", serialNum++, contactList[name].email);
            }
            if (purpose.ToLower() == "update" && contactList.ContainsKey(name))
                UpdateContact(name);
            if (purpose.ToLower() == "remove" && contactList.ContainsKey(name))
                RemoveContact(name);
        }
        public void UpdateContact()
        {
            Console.WriteLine("\nEnter the name of candidate to be updated");
            string name = Console.ReadLine().ToLower();
            DisplayContactDetails(name, "update");
        }
        public void UpdateContact(string name)
        {
            //Getting the attribute to be updated
            Console.WriteLine("\nEnter the row number attribute to be updated");
            int updateAttributeNum = Convert.ToInt32(Console.ReadLine());

            //Gegting the new value of attribute
            Console.WriteLine("\nEnter the new value to be entered");
            string newValue = Console.ReadLine();

            //Updating selected attribute with selected value
            switch (updateAttributeNum)
            {
                case UPDATE_FIRST_NAME:
                    contactList[name].firstName = newValue;
                    break;
                case UPDATE_LAST_NAME:
                    contactList[name].lastName = newValue;
                    break;
                case UPDATE_ADDRESS:
                    contactList[name].address = newValue;
                    break;
                case UPDATE_CITY:
                    contactList[name].city = newValue;
                    break;
                case UPDATE_STATE:
                    contactList[name].state = newValue;
                    break;
                case UPDATE_ZIP:
                    contactList[name].zip = newValue;
                    break;
                case UPDATE_PHONE_NUMBER:
                    contactList[name].phoneNumber = newValue;
                    break;
                case UPDATE_EMAIL:
                    contactList[name].email = newValue;
                    break;
                default:

                    break;
            }
            Console.WriteLine("\nUpdate Successful");
        }
        public void RemoveContact()
        {
            Console.WriteLine("\nEnter the name of contact to be removed");
            string name = Console.ReadLine().ToLower();
            DisplayContactDetails(name, "remove");

        }
        private void RemoveContact(string name)
        {
            Console.WriteLine("Press y to confirm delete or any other key to abort");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                    contactList.Remove(name);
                    Console.WriteLine("Contact deleted");
                    break;
                default:
                    Console.WriteLine("Deletion aborted");
                    break;
            }
        }
    }
}
