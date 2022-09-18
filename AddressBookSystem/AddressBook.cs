using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class AddressBook : IAddressBook
    {
        public Dictionary<string, ContactDetails> contactList = new Dictionary<string, ContactDetails>();
        public void AddContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            ContactDetails addNewContact = new ContactDetails(firstName, lastName, address, city, state, zip, phoneNumber, email);
            contactList.Add(firstName + lastName, addNewContact);
            Console.WriteLine("Contact Added");
        }

        public void DisplayPhoneNumber(string Name)
        {
            foreach (KeyValuePair<string, ContactDetails> keyValuePair in contactList)
            {
                if ((keyValuePair.Key).Contains(Name))
                    Console.WriteLine("Phone number of {0} is {1}", Name, (keyValuePair.Value).phoneNumber);
            }

        }
    }
}
