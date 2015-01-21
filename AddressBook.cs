using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_CS
{
    [Serializable]
    class AddressBook
    {   
        public Dictionary<string, Contact> Contacts = null;
        public AddressBook()
        {
            Contacts = new Dictionary<string, Contact>();
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact.FullName, contact);
        }

        public Contact GetContact(string fullName)
        {
            return Contacts[fullName];
        }

    }
}
