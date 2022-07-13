//Name: Sotonte Bob-manuel
//Professor: Ron Enz
//Class: C# Programming CIST 2342_Lab02
//Date: 25th of August,2021.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registeration
{
    public class Address
    {
        private String street;
        private String city;
        private String state;
        private int zip;

        public Address() //Default constructor
        {
            street = "123 LakeWood St";
            city = "Atlanta";
            state = "Georgia";
            zip = 30303;
        }

        public Address(String Street, String City, String State, int ZIP) //Constructor that passes variables
        {
            street = Street;
            city = City;
            state = State;
            zip = ZIP;
        }

        //Set and get methods for the variables instantiated
        public String Street
        {
            set { street = value; }
            get { return street; }
        }

        public String City
        {
            set { city = value; }
            get { return city; }
        }

        public String State
        {
            set { state = value; }
            get { return state; }
        }

        public int ZIP
        {
            set { zip = value; }
            get { return zip; }
        }

        public void Display() //Display method to display all the data received
        {
            Console.WriteLine("Street: " + street);
            Console.WriteLine("City: " + city);
            Console.WriteLine("State: " + state);
            Console.WriteLine("ZIP: " + zip);
            Console.WriteLine("=======================");
            Console.WriteLine("=======================");
        }
    }
}
