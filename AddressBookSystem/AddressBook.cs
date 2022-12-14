using AddressBookSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class AddressBook
    {
       // Constants
        private const int UPDATE_FIRST_NAME = 1;
        private const int UPDATE_LAST_NAME = 2;
        private const int UPDATE_ADDRESS = 3;
        private const int UPDATE_CITY = 4;
        private const int UPDATE_STATE = 5;
        private const int UPDATE_ZIP = 6;
        private const int UPDATE_PHONE_NUMBER = 7;
        private const int UPDATE_EMAIL = 8;

        // Variables
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private string zip;
        private string phoneNumber;
        private string email;
        private int contactSerialNum = 0;
        public string nameOfAddressBook = " ";

        // Object initialisation
        public List<ContactDetails> contactList = new List<ContactDetails>();
        // Stores the name of address book when an object is initiated
        public AddressBook(string name)
        {
            nameOfAddressBook = name;
        }
        // Adds the contact.
        public void AddContact()
        {
            // Getting FirstName
            Console.WriteLine("\nEnter The First Name of Contact");
            firstName = Console.ReadLine();

            // Getting lastName
            Console.WriteLine("\nEnter The Last Name of Contact");
            lastName = Console.ReadLine();

            // Getting Address
            Console.WriteLine("\nEnter The Address of Contact");
            address = Console.ReadLine();

            // Getting city name
            Console.WriteLine("\nEnter The City Name of Contact");
            city = Console.ReadLine().ToLower();

            // Getting state name
            Console.WriteLine("\nEnter The State Name of Contact");
            state = Console.ReadLine().ToLower();

            // Getting zip of locality
            Console.WriteLine("\nEnter the Zip of Locality of Contact");
            zip = Console.ReadLine();

            // Getting Phone number
            Console.WriteLine("\nEnter The Phone Number of Contact");
            phoneNumber = Console.ReadLine();

            // Getting Email of contact
            Console.WriteLine("\nEnter The Email of Contact");
            email = Console.ReadLine();

            // Creating an instance of contact with given details
            ContactDetails addNewContact = new ContactDetails(firstName, lastName, address, city, state, zip, phoneNumber, email, nameOfAddressBook);

            // Checking for duplicates with the equals method
            // Loop continues till the given contact doesnt equal to any available contact
            while (addNewContact.Equals(contactList))
            {
                Console.WriteLine("contact already exists");
                // Giving option to user to re enter or to exit
                Console.WriteLine("Type Y to enter new name or any other key to exit");
                // If user wants to re-enter then taking input from user
                // Else return 
                if ((Console.ReadLine().ToLower() == "y"))
                {
                    Console.WriteLine("Enter new first name");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Enter new last name");
                    lastName = Console.ReadLine();
                    addNewContact = new ContactDetails(firstName, lastName, address, city, state, zip, phoneNumber, email, nameOfAddressBook);
                }
                else
                    return;
            }
            // Adding the contact to list
            contactList.Add(addNewContact);

            // Adding contact to city dictionary
            AddressBookDetails.AddToCityDictionary(city, addNewContact);

            // Adding contact to state dictionary
            AddressBookDetails.AddToStateDictionary(state, addNewContact);
        }
        // Displays the contact details.
        public void DisplayContactDetails()
        {
            // If the List doesnt have any contacts
            // Else get the name to search for details
            if (contactList.Count() == 0)
                Console.WriteLine("No saved contacts");
            else
            {
                Console.WriteLine("\nEnter the name of candidate to get Details");
                string name = Console.ReadLine().ToLower();
                // Search the contact by name
                ContactDetails contact = SearchByName(name);
                // Print the details of the contact after search
                ToString(contact);
            }
        }
        // Updates the contact.
        public void UpdateContact()
        {
            // If the List have no contacts
            if (contactList.Count() == 0)
            {
                Console.WriteLine("No saved contacts");
                return;
            }
            // Input the name to be updated
            Console.WriteLine("\nEnter the name of candidate to be updated");
            string name = Console.ReadLine();
            // Search the name
            ContactDetails contact = SearchByName(name);
            // To print details of searched contact
            ToString(contact);
            // If contact doesnt exist
            if (contact == null)
                return;
            int updateAttributeNum = 0;
            // Getting the attribute to be updated
            Console.WriteLine("\nEnter the row number attribute to be updated or 0 to exit");
            try
            {
                updateAttributeNum = Convert.ToInt32(Console.ReadLine());
                if (updateAttributeNum == 0)
                    return;
            }
            catch
            {
                Console.WriteLine("Invalid entry");
                return;
            }

            // Getting the new value of attribute
            Console.WriteLine("\nEnter the new value to be entered");
            string newValue = Console.ReadLine();

            // Updating selected attribute with selected value
            switch (updateAttributeNum)
            {
                case UPDATE_FIRST_NAME:

                    // Store the firstname of given contact in variable
                    firstName = contact.firstName;

                    // Update the contact with given name
                    contact.firstName = newValue;

                    // If duplicate contact exists with that name then revert the operation
                    if (contact.Equals(contactList))
                    {
                        contact.firstName = firstName;
                        Console.WriteLine("Contact already exists with that name");
                        return;
                    }
                    break;
                case UPDATE_LAST_NAME:

                    // Store the LastName of given contact in variable
                    lastName = contact.lastName;

                    // Update the contact with given name
                    contact.lastName = newValue;

                    // If duplicate contact exists with that name then revert the operation
                    if (contact.Equals(contactList))
                    {
                        contact.lastName = lastName;
                        Console.WriteLine("Contact already exists with that name");
                        return;
                    }
                    break;
                case UPDATE_ADDRESS:
                    contact.address = newValue;
                    break;
                case UPDATE_CITY:
                    // Remove the contact from city dictionary
                    AddressBookDetails.cityToContactMap[contact.city].Remove(contact);
                    // Update the contact city
                    contact.city = newValue;
                    // Add to city dictionary
                    AddressBookDetails.AddToCityDictionary(contact.city, contact);
                    break;
                case UPDATE_STATE:
                    // Remove the contact from state dictionary
                    AddressBookDetails.stateToContactMap[contact.state].Remove(contact);
                    // Update the contact state
                    contact.state = newValue;
                    // Add to state dictionary
                    AddressBookDetails.AddToStateDictionary(contact.state, contact);
                    break;
                case UPDATE_ZIP:
                    contact.zip = newValue;
                    break;
                case UPDATE_PHONE_NUMBER:
                    contact.phoneNumber = newValue;
                    break;
                case UPDATE_EMAIL:
                    contact.email = newValue;
                    break;
                default:
                    Console.WriteLine("Invalid Entry");
                    return;
            }
            Console.WriteLine("\nUpdate Successful");
        }
        // Removes the contact.
        public void RemoveContact()
        {
            // If the List does not have any contacts
            if (contactList.Count() == 0)
            {
                Console.WriteLine("No saved contacts");
                return;
            }
            // Input the name of the contact to be removed
            Console.WriteLine("\nEnter the name of contact to be removed");
            string name = Console.ReadLine().ToLower();
            // Search for the contact
            ContactDetails contact = SearchByName(name);
            // Print the details of contact for confirmation
            ToString(contact);
            // If contact doesnt exist then exit
            if (contact == null)
                return;
            // Asking for confirmation to delete contact
            // If user says yes(y) then delete the contact
            Console.WriteLine("Press y to confirm delete or any other key to abort");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                    contactList.RemoveAt(contactSerialNum);
                    Console.WriteLine("Contact deleted");
                    break;
                default:
                    Console.WriteLine("Deletion aborted");
                    break;
            }
        }
        /// Gets all contacts.
        public void GetAllContacts()
        {
            // If the List does not have any contacts
            if (contactList.Count() == 0)
            {
                Console.WriteLine("\nNo saved contacts");
                return;
            }
            // Display all contact details in list
            foreach (ContactDetails contact in contactList)
                ToString(contact);
        }
        // Display the details of given contact
        public static void ToString(ContactDetails contact)
        {
            if (contact == null)
            {
                Console.WriteLine("Contact Not found");
                return;
            }
            // Display all the atributes of contact
            int rowNum = 1;
            Console.WriteLine("\nDetails of: {0}", contact.firstName + " " + contact.lastName);
            Console.WriteLine("{0}-Firstname: {1}", rowNum++, contact.firstName);
            Console.WriteLine("{0}-Lastname: {1}", rowNum++, contact.lastName);
            Console.WriteLine("{0}-Address: {1}", rowNum++, contact.address);
            Console.WriteLine("{0}-City: {1}", rowNum++, contact.city);
            Console.WriteLine("{0}-State: {1}", rowNum++, contact.state);
            Console.WriteLine("{0}-Zip code: {1}", rowNum++, contact.zip);
            Console.WriteLine("{0}-PhoneNumber: {1}", rowNum++, contact.phoneNumber);
            Console.WriteLine("{0}-Email ID: {1}", rowNum++, contact.email);
        }
        // Searches the contact by name.
        private ContactDetails SearchByName(string name)
        {
            // If the list is empty
            if (contactList.Count == 0)
                return null;
            int numOfContactsSearched = 0;

            // storing the count of contacts with searched name string
            int numOfConatctsWithNameSearched = 0;

            // Search if Contacts have the given string in name
            foreach (ContactDetails contact in contactList)
            {
                // Incrementing the no of contacts searched
                numOfContactsSearched++;

                // If contact name matches exactly then it returns the index of that contact
                if ((contact.firstName + " " + contact.lastName).Equals(name))
                    return contact;

                // If a part of contact name matches then we would ask them to enter accurately
                if ((contact.firstName + " " + contact.lastName).Contains(name))
                {
                    // num of contacts having search string
                    numOfConatctsWithNameSearched++;
                    Console.WriteLine("\nname of contact is {0}", contact.firstName + " " + contact.lastName);
                }
                // If string is not part of any name then exit
                if (numOfContactsSearched == contactList.Count() && numOfConatctsWithNameSearched == 0)
                    return null;
            }
            // Ask to enter name accurately
            Console.WriteLine("\nInput the contact name as firstName lastName\n or E to exit");
            name = Console.ReadLine();
            // To exit
            if (name.ToLower() == "e")
                return null;
            // To continue search with new name
            return SearchByName(name);
        }
    }
}