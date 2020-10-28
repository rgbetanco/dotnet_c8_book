using System;
using static System.Console;
using CryptographyLib;

namespace EncryptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var plainText = "Hello World";
            var password = "pliocene";
            var resE = Protector.Encrypt(plainText, password);
            WriteLine(resE);
            var resD = Protector.Decrypt(resE, password);
            WriteLine(resD);
        }
    }
}
