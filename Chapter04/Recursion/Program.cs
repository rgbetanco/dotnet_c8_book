using System;
using static System.Console;

namespace Recursion
{
    class Program
    {
        /// <summary>
        /// Pass an integer and it will calculate the factor value of the integer
        /// </summary>
        /// <param name="number">Number is any integer value, ex: 1,2,3,4,5 etc</param>
        /// <returns></returns>
        static int Factorial(int number){
            if(number < 1){
                return 0;
            } else if (number == 1){
                return 1;
            } else {
                return number * Factorial(number - 1);
            }
        }

        static void RunFactorial(){
            bool isNumber; 
            do { 
                Write("Enter a number: "); 
                isNumber = int.TryParse( ReadLine(), out int number); 
                if (isNumber) { 
                    WriteLine( $"{number:N0}! = {Factorial(number):N0}");
                } else { 
                    WriteLine("You did not enter a valid number!"); 
                } 
            } while (isNumber);
        }
        static void Main(string[] args)
        {
            RunFactorial();
        }
    }
}
