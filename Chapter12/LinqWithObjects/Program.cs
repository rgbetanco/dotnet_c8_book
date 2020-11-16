using System;
using static System.Console;
using System.Linq;

namespace LinqWithObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqWithArrayOfStrings();
        }

        static void LinqWithArrayOfStrings(){
            var names = new string[]{"Michael","Pam","Jim","Dwight","Angela","Kevin","Toby","Creed"};
            var query = names.Where(new Func<string, bool>(NameLongerThanFour));
            foreach (string item in query)
            {
                WriteLine(item);
            }
        }
        static bool NameLongerThanFour(string name){
            return name.Length > 4;
        } 
    }
}
