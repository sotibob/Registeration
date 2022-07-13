//Name: Sotonte Bob-manuel
//Professor: Ron Enz
//Class: C# Programming CIST 2342_Lab04
//Date: 8th of September,2021.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registeration
{
    public class Person
    {
        private String firstName;
        private String lastName;
        private String email;
        private Address address;
        private Schedule schedule;

        public Person() //Default Constructor
        {
            firstName = "Scott";
            lastName = "Peters";
            email = "scottpeters@gmail.com";
            address = new Address();
            schedule = new Schedule();
        }

        public Person(String FirstName, String LastName, String Email, Address Address) // Constructor that passes variables
        {
            firstName = FirstName;
            lastName = LastName;
            email = Email;
            address = Address;
        }

        //Set and get methods for the variables instantiated
        public String FirstName
        {
            set { firstName = value; }
            get { return firstName; }
        }

        public String LastName
        {
            set { lastName = value; }
            get { return lastName; }
        }

        public String Email
        {
            set { email = value; }
            get { return email; }
        }

        public Address Address
        {
            set { address = value; }
            get { return address; }
        }

        public void addSection(Section s)
        {
            schedule.addSection(s);
        }

        public void Display() // Display method to display all the data received
        {
            Console.WriteLine("FirstName: " + firstName);
            Console.WriteLine("LastName: " + lastName);
            Console.WriteLine("Email: " + email);
            address.Display();
            schedule.Display();
            Console.WriteLine("=======================");
            Console.WriteLine("=======================");
        }
    }
}
