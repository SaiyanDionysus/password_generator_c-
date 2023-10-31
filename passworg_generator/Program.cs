using System;
using System.Text;
using System.Security;
using System.Security.Cryptography;

namespace GeneratePassword
{
    class Program
    {
        private const string CHAR_POOL = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+[]{};:'\",./?`~";
        private const int DEFAULT_LENGTH = 14;

        static void Main(string[] args)
        {
            Console.WriteLine(GeneratePassword(12));
            Console.WriteLine(GeneratePassword(16));
            Console.WriteLine(GeneratePassword(18));
            Console.WriteLine(GeneratePassword(9));
            Console.ReadLine();
        }

        public static string GeneratePassword(int length)
        {
            if (length < 2)
            {
                length = DEFAULT_LENGTH;
            }

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                byte[] randomNumber = new byte[1];
                rng.GetBytes(randomNumber);

                int index = randomNumber[0] % CHAR_POOL.Length;
                password.Append(CHAR_POOL[index]);
            }

            return password.ToString();
        }

    }
}