using System.Text.RegularExpressions;
namespace PacktLibrary
{
    public static class StringExtensions
    {
        public static bool isValidEmail(this string input)
        {
            return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
    }
}