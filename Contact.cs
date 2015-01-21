using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_CS
{
    [Serializable]
    class Contact
    {
        string[] Name = new string[2];

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }



        public string FullName { get; set; }



        public Contact(string fullName, long phoneNumber)
        {
            FullName = fullName;
            Name = FullName.Split(' ');
            FirstName = Name[0];
            LastName = Name[1];
            PhoneNumber = phoneNumber;
        }

        public string GetDetails()
        {
            return "Name: " + FullName + Environment.NewLine + "Phone Number: " + PhoneNumber;
        }




    }
}
