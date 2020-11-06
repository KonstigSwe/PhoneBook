using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PhoneBook
{
    class Program
    {
        class Contacts
        {

            public string firstName, lastName, address, email, phone;
            public Contacts(string fName, string lName, string addr, string mail, string call)
            {
                firstName = fName;
                lastName = lName;
                address = addr;
                email = mail;
                phone = call;

            }

        }
        static void Main(string[] args)
        {
            string fileLocation = @"C:\Users\nikla\Documents\Visual_studio_code\Addreses.TXT";
            List<Contacts> contact = new List<Contacts>();
            string line;
            using (StreamReader read = new System.IO.StreamReader(fileLocation))
            {
                while ((line = read.ReadLine()) != null)
                {
                    string[] words = line.Split('#');

                    contact.Add(new Contacts(words[0], words[1], words[2], words[3], words[4]));
                }
                read.Close();
            }
            string userComand;
            do
            {
                Console.WriteLine("Write your comand: write 'help' to show commands:");
                userComand = Console.ReadLine();
                if (userComand == "add")
                {
                    Add(contact);

                }
                else if (userComand == "show")
                {
                    Show(contact);
                }
                else if (userComand == "save")
                {
                    Save(contact, fileLocation);
                }
                else if (userComand == "delete")
                {
                    Delete(contact);
                }
                else if (userComand == "quit")
                {
                    Console.WriteLine("Do you want to save? yes/no");
                    string ans = Console.ReadLine();
                    if (ans == "yes")
                    {
                        Save(contact, fileLocation);
                    }
                    Console.WriteLine("Good bye");

                }
                else if (userComand == "help")
                {
                    Console.WriteLine("Write save to save your phone book to the pc.");
                    Console.WriteLine("Write delete to delete a contact (remember to save after).");
                    Console.WriteLine("Write show to show the contacts you have.");
                    Console.WriteLine("Write add to add a contact to your contact list (remember to save).");
                    Console.WriteLine("Write quit to quit the pogram obs it will ask you if you want to save or not.");
                }
                else
                {
                    Console.WriteLine("Unknown command: {0}", userComand);
                }
                Console.WriteLine();
            } while (userComand != "quit");

            Console.ReadKey();
        }
        static void Add(List<Contacts> contact)
        {
            Console.Write("First name:  ");
            string fname = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Last name: ");
            string lname = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.WriteLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Phone number: ");
            string phon = Console.ReadLine();
            Console.WriteLine("Name: {0} {1} Address: {2} E-mail: {3} Phone: {4}", fname, lname, address, email, phon);
            contact.Add(new Contacts(fname, lname, address, email, phon));
        }
        static void Show(List<Contacts> contact)
        {
            Console.WriteLine("First name-|-second name----|---Address--|---E-Mail-----|-----Phone number------");
            for (int i = 0; i < contact.Count(); i++)
            {
                if (contact[i] != null)
                {
                    Console.WriteLine("| {0,-10} | {1,-10} | {2,-15} | {3,-25} | {4,-10}|", contact[i].firstName, contact[i].lastName, contact[i].address, contact[i].email, contact[i].phone);

                }
            }
            Console.WriteLine("------------------------------------------------------------------------------");
        }
        static void Save(List<Contacts> contact, string fileLocation)
        {
            using (System.IO.StreamWriter writer = new StreamWriter(fileLocation))
            {
                for (int i = 0; i < contact.Count(); i++)
                {
                    writer.WriteLine("{0}#{1}#{2}#{3}#{4}", contact[i].firstName, contact[i].lastName, contact[i].address, contact[i].email, contact[i].phone);
                }
            }
            Console.WriteLine("Saved");
        }
        static void Delete(List<Contacts> contact)
        {
            Console.Write("Write the first name of the person you want to delete: ");
            string remove = Console.ReadLine();

            for (int i = 0; i < contact.Count(); i++)
            {
                if (remove == contact[i].firstName)
                {
                    Console.WriteLine("Deleted the information belonging to {0}", remove);
                    Console.WriteLine();
                    Console.WriteLine("Found {0} on row {1}", remove, i);
                    contact.RemoveAt(i);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Did not find the person at row {0}", i);
                }
            }
        }
    }
}
