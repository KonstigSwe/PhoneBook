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
                    Console.WriteLine("{0}", line);
                    contact.Add(new Contacts(words[0], words[1], words[2], words[3], words[4]));
                }
                read.Close();
            }
            string userComand;
            do
            {
                Console.WriteLine("Write your comand");
                userComand = Console.ReadLine();
                if (userComand == "add")
                {
                    Add(contact);

                }
                else if (userComand == "show")
                {
                    Show(contact);
                }
                else if(userComand == "save")
                {
                    Save(contact, fileLocation);
                }

            } while (userComand != "quit");
            Console.WriteLine("Good bye");
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
                    Console.WriteLine("| {0,-10} | {1,-10} | {2,-15} | {3,-25} | {4,-20} |", contact[i].firstName, contact[i].lastName,contact[i].address,contact[i].email,contact[i].phone);

                }
            }
            Console.WriteLine("------------------------------------------------------------------------------");
        }
        static void Save(List<Contacts> contact,string fileLocation)
        {
            using (System.IO.StreamWriter writer = new StreamWriter(fileLocation))
            {
                for (int i = 0; i < contact.Count(); i++)
                {
                    writer.WriteLine("{0}#{1}#{2}##{3}##{4}", contact[i].firstName, contact[i].lastName, contact[i].address, contact[i].email, contact[i].phone);
                }
            }
            Console.WriteLine("Saved");
        }
    }
}
