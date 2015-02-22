using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_CS
{
    internal class Program
    {
        public static string FullName { get; set; }

        public static string PhoneNumber { get; set; }
        public static string Email { get; set;}

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
                Console.WriteLine("Enter full name to get or add a contact.");
                Console.WriteLine("Type delete to delete a contanct." + Environment.NewLine);
                Console.WriteLine("Contacts: " + addressBook.Contacts.Count);
                Console.WriteLine("© Meraj Ahmed");
                FullName = Console.ReadLine();
                Console.Clear();

                if (FullName.ToLower() == "save")
                {
                    SaveFile(formatter, addressBook);
                    Console.Clear();

                    Console.WriteLine("Contacts saved.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (FullName.ToLower() == "delete")
                {
                    Console.WriteLine("Type the full name of the contact you would like to delete.");
                    FullName = Console.ReadLine();
                    Console.Clear();

                    addressBook.Contacts.Remove(FullName);
                    SaveFile(formatter, addressBook);

                    Console.WriteLine("Contact successfully deleted.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    if (!addressBook.Contacts.Keys.Contains(FullName))
                    {
                        do
                        {
                            Console.WriteLine("Enter phone number.");
                            PhoneNumber = Console.ReadLine();
                            if (PhoneNumber == "")
                            {
                                Console.WriteLine("Phone number is required.");
                                Console.ReadLine();
                                Console.Clear();

                                PhoneNumber = "Invalid";
                            }
                        } while (PhoneNumber == "Invalid");

                        Console.WriteLine("Enter email address (optional).");
                        Email = Console.ReadLine();
                        if (Email == "") Email = "N/A";


                        contacts.Add(new Contact(FullName, PhoneNumber, Email));
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
