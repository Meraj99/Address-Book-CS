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
        private Dictionary<string, Contact> _contacts; //Hmm, this doesn't exist in the current context
        public Dictionary<string, Contact> Contacts
        {
            get { return _contacts ?? (_contacts = new Dictionary<string, Contact>()); }
            set { _contacts = value; }
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
