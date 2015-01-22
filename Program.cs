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

        public static long PhoneNumber { get; set; }

        static void SaveFile(BinaryFormatter formatter, AddressBook addressBook)
        {
            using (Stream output = File.Create("contacts.dat"))
            {
                formatter.Serialize(output, addressBook);
            }
        }

        static AddressBook LoadFile(BinaryFormatter formatter)
        {
            if (File.Exists("contacts.dat"))
            {
                AddressBook addressBook;
                using (Stream input = File.OpenRead("contacts.dat"))
                {
                    addressBook = (AddressBook) formatter.Deserialize(input);
                }
                return addressBook;
            }
            else
            {
                Console.WriteLine("File does not exist.");
                return new AddressBook();
            }
        }

        static void Main(string[] args)
        {
            var formatter = new BinaryFormatter();
            AddressBook addressBook;

            var contacts = new List<Contact>();

            if (File.Exists("contacts.dat"))
            {
                addressBook = LoadFile(formatter);
            }
            else
            {
                addressBook = new AddressBook();
                SaveFile(formatter, addressBook);
            }

            while(true){
                Console.WriteLine("Enter full name to get or add a contact." + Environment.NewLine);
                Console.WriteLine("Contacts: " + addressBook.Contacts.Count);
                FullName = Console.ReadLine();


                if (FullName.ToLower() == "save")
                {
                    SaveFile(formatter, addressBook);
                    Console.Clear();

                    Console.WriteLine("Contacts saved.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    if (!addressBook.Contacts.Keys.Contains(FullName))
                    {
                        Console.Clear();
                        Console.WriteLine("Enter phone number to add contact.");
                        PhoneNumber = Convert.ToInt64(Console.ReadLine());

                        contacts.Add(new Contact(FullName, PhoneNumber));
                        addressBook.AddContact(contacts[contacts.Count - 1]);
                        SaveFile(formatter, addressBook);
                        
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(addressBook.Contacts[FullName].GetDetails());
                        Console.ReadLine();
                    }
                    Console.Clear();
                }
            }
        }
    }
}
