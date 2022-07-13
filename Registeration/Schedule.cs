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
    public class Schedule
    {
        public int count = 0;
        public Section[] s1 = new Section[10];

        public Schedule() //Default Constructor
        {
            
        }

        public void addSection(Section s) //method to add a section to your schedule
        {
            s1[count] = s;
            count++;
        }

        public void Display() //Display method to display and loop through all the data received in the array
        {
            for (int i = 0; i < count; i++)
            {
                s1[i].Display();
            }
        }
    }
}
