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
            byte[] randomBytes = Protector.GetRandomKeyOrIV(256);
            WriteLine($"Key as byte array");
            for (int i = 0; i < randomBytes.Length; i++)
            {
                Write($"{randomBytes[i]:x2} ");
                if(((i+1)%16) == 0)WriteLine();
            }
            WriteLine();
        }
    }
}
