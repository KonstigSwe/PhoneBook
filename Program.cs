using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Program
    {
        class Contacts
        {

           public string firstName, lastName, address, email, phone;
            public Contacts(string fName,string lName,string addr,string mail, string call)
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
            List<Contacts> Contact = new List<Contacts>();
            string line;
            using (StreamReader read = new System.IO.StreamReader(fileLocation))
            {
                while ((line = read.ReadLine()) != null)
                {
                    string[] words = line.Split('#');
                    Console.WriteLine("{0}", line);
                    Contact.Add(new Contacts(words[0], words[1],words[2],words[3],words[4]));
                }
                read.Close();
            }

        }
    }
}
