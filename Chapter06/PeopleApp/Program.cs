using System;
using static System.Console;
using PacktLibrary;

namespace PeopleApp
{
    class Program
    {
        private static void Harry_Shout(object sender, EventArgs e){
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
        }
        static void Main(string[] args)
        {
            var Harry = new Person{ Name = "Harry" };
            var Mary = new Person{ Name = "Mary" };
            var Jill = new Person{ Name = "Jill" };
            var baby1 = Mary.ProcreateWith(Harry);
            //calling static method
            var baby2 = Person.Procreate(Harry, Jill);
            var baby3 = Mary * Jill;

            WriteLine($"{Harry.Name} has {Harry.Children.Count} children");
            WriteLine($"{Mary.Name} has {Mary.Children.Count} children");
            WriteLine($"{Jill.Name} has {Jill.Children.Count} children");

            WriteLine(format: "{0}'s first child is named \"{1}\".", arg0:Harry.Name, arg1: Harry.Children[0].Name);

            WriteLine($"5! is {Person.Factorial(5)}");

            Harry.Shout += Harry_Shout;
            Harry.Poke();
            Harry.Poke();
            Harry.Poke();
            Harry.Poke();

            Person[] people = {
                new Person { Name = "Simon" },
                new Person { Name = "Jenny" },
                new Person { Name = "Adam" },
                new Person { Name = "Richard" }
            };
            WriteLine("Initial list of people");
            foreach(var person in people){
                WriteLine($"{person.Name}");
            }
            WriteLine("User's person IComparable implementation to sort");
            Array.Sort(people);
            foreach(var person in people){
                WriteLine($"{person.Name}");
            }

            WriteLine("Use person comparer implementation to sort");
            Array.Sort(people, new PersonComparer());
            foreach(var person in people){
                WriteLine($"{person.Name}");
            }
            // WORKING WITH GENERIC TYPES
            var t1 = new Thing();
            t1.Data = 42;
            WriteLine($"Thing with an integer {t1.Process(42)}");
            var t2 = new Thing();
            t2.Data = "apple";
            WriteLine($"Thing with an string {t2.Process("apple")}");

            var t3 = new GenericThing<int>();
            t3.Data = 42;
            WriteLine($"GenericThing with an integer {t3.Process(42)}");
            var t4 = new GenericThing<string>();
            t4.Data = "apple";
            WriteLine($"GenericThing with an string {t4.Process("apple")}");

            //WORKING WITH GENERIC METHODS
            var number1 = "4";
            WriteLine("{0} square is {1}", arg0: number1, arg1: Squarer.Square<string>(number1));

            byte number2 = 3;
            WriteLine("{0} square is {1}", arg0: number2, arg1: Squarer.Square<byte>(number2));

            // INHERITING FROM CLASSES
            Employee emp = new Employee {
                Name = "Ronald Garcia",
                DateOfBirth = new DateTime(1970,12,10)
            };
            emp.WriteToConsole();
            emp.EmployeeCode = "RGB001";
            emp.HireDate = new DateTime(2020, 12, 10);
            WriteLine($"{emp.EmployeeCode} was hired on {emp.HireDate:dd/MM/yy}");
            WriteLine($"{emp.ToString()}");

            //INHERITING AND EXTENDING .NET TYPES
            try {
                emp.TimeTravel(new DateTime(1969, 10, 10));
            }
            catch(PersonException ex)
            {
                WriteLine(ex.Message);
            }
            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";
            WriteLine("{0} is a valid e-mail address:{1}",arg0: email1, arg1: StringExtensions.isValidEmail(email1));
            WriteLine("{0} is a valid e-mail address:{1}",arg0: email2, arg1: email2.isValidEmail());

        }
    }
}
