using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public enum PasswordOptions
    {
        HasUpperCase,
        OnlyUpperCase,
        OnlyLowerCase,
        AtLeastOneDigitOneSpecialCharacter
    }
    public class Password
    {
        private readonly string password;

        private const string UpperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string AlphaNumericLower = "0123456789abcdefghijklmnopqrstuvwxyz";
        private const string AlphaNumericWithUpperCase = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string AlphaNumericUpper = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Password(string str)
        {
            password = str;
        }
        public Password(PasswordOptions passOpt)
        {
            
        }
        public static Password NewPassword(PasswordOptions option, int length = 32)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var data = new byte[4];

                rng.GetBytes(data);

                var seed = BitConverter.ToInt32(data, 0);

                var rnd = new Random(seed);

                var passChars = new char[length];

                var sb = new StringBuilder();
                for (var i = 0; i < passChars.Length; i++)
                {
                    if (option == PasswordOptions.HasUpperCase) sb.Append(AlphaNumericWithUpperCase[rnd.Next(0, 63)]);
                    if (option == PasswordOptions.OnlyUpperCase) sb.Append(AlphaNumericUpper[rnd.Next(0, 37)]);
                    if (option == PasswordOptions.OnlyLowerCase) sb.Append(AlphaNumericLower[rnd.Next(0, 37)]);
                }

                var pass = new Password(sb.ToString());

                return pass;
            }
        }
        public new string ToString()
        {
            return password;
        }
    }
}
