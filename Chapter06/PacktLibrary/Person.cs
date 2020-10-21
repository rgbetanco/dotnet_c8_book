using System;
using System.Collections.Generic;
using static System.Console;

namespace PacktLibrary
{
    public class Person : IComparable<Person>
    {
        //event delegate field
        public event EventHandler Shout;
        //data field
        public int AngerLevel;
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();
        public void Poke(){
            AngerLevel++;
            if (AngerLevel >= 3){
                if (Shout != null){
                    Shout(this, EventArgs.Empty);
                }
            }
        }
        public void WriteToConsole(){
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}");
        }
        public static Person Procreate(Person p1, Person p2){
            var baby = new Person{
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };
            p1.Children.Add(baby);
            p2.Children.Add(baby);
            //delegate
            var d = new DelegateWithMatchingSignature(p1.MethodIWantToCall);
            int answer2 = d("Frog");
            WriteLine($"Frog has {answer2} characters");
            //end delegate
            return baby;
        }
        //using operator to procreate
        public static Person operator *(Person p1, Person p2){
            return Person.Procreate(p1, p2);
        }
        public Person ProcreateWith(Person partner){
            return Procreate(this, partner);
        }
        public static int Factorial(int number){
            if(number < 0){
                throw new ArgumentException(
                    $"{nameof(number)} cannot be less than zero."
                );
            }
            return localFactorial(number);
            int localFactorial(int localNumber) 
            {
                if(localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber - 1);
            }
        }
        // delegates
        public int MethodIWantToCall(string input){
            return input.Length;
        }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }

        delegate int DelegateWithMatchingSignature(string s);
        public override string ToString()
        {
            return $"{Name} is a {base.ToString()}";
        }
        public void TimeTravel(DateTime when) {
            if (when <= DateOfBirth)
            {
                throw new PersonException("If you travel back in time to a date earlier than your own birht,then the universe will explode!");
            }
            else 
            {
                WriteLine($"Welcome to {when:yyyy}!");
            }
        }
    }
}
