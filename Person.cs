using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_Events
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;


        public Person() : this("firstName", "lastName", 0) { }

        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            Age = age;
        }


        public string Name => (firstName + " " + lastName);

        public int Age
        {
            get => age;
            set
            {
                if (value < 0) throw new ArgumentException("Parameter age must be >= 0");
                age = value;
            }
        }


        public void Jump(object sender, EventArgs e)
        {
            Console.WriteLine($"{Name} is jump!");
        }

        public void Select(object sender, EventArgs e)
        {
            Console.WriteLine($"{Name} is selectes!");
        }

        public void Move(object sender, EventArgs e)
        {
            Console.WriteLine($"{Name} moves to the {(e as MyEventArgs).Direction}");
        }
    }
}
