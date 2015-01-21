using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_CS
{
    class Program
    {
        public static string FullName { get; set; }

        public static int PhoneNumber { get; set; }

        static void Main(string[] args)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            AddressBook addressBook = new AddressBook();

            Contact contact1 = null;
            Contact contact2 = null;
            Contact contact3 = null;
            Contact contact4 = null;
            Contact contact5 = null;

            while (true) { 
            if (!File.Exists("contacts.dat"))
            {
                using (Stream output = File.Create("contacts.dat"))
                {
                    formatter.Serialize(output, addressBook);
                }
            }
            else
            {
                using (Stream input = File.OpenRead("contacts.dat"))
                {
                    addressBook = (AddressBook) formatter.Deserialize(input);
                }
            }

            

            Console.WriteLine("Enter full name to get or add a contact.");
            FullName = Console.ReadLine();

                if (!addressBook.Contacts.ContainsKey(FullName)) //NullReferenceException here... <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                {
                    Console.WriteLine("Enter phone number to add contact.");
                    PhoneNumber = Convert.ToInt32(Console.ReadLine());
                    if (contact1 == null)
                    {
                        contact1 = new Contact(FullName, PhoneNumber);
                        addressBook.Contacts.Add(FullName, contact1);
                    }
                    else if (contact2 == null)
                    {
                        contact2 = new Contact(FullName, PhoneNumber);
                        addressBook.Contacts.Add(FullName, contact2);
                    }
                    else if (contact3 == null)
                    {
                        contact3 = new Contact(FullName, PhoneNumber);
                        addressBook.Contacts.Add(FullName, contact3);
                    }
                    else if (contact4 == null)
                    {
                        contact4 = new Contact(FullName, PhoneNumber);
                        addressBook.Contacts.Add(FullName, contact4);
                    }
                    else if (contact5 == null)
                    {
                        contact5 = new Contact(FullName, PhoneNumber);
                        addressBook.Contacts.Add(FullName, contact5);
                    }
                }
                else
                {
                    Console.WriteLine(addressBook.Contacts[FullName].GetDetails());
                }
                Console.Clear();
            }
        }
    }
}
