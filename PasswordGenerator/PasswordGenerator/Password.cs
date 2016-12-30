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
        OnlyAlphabet,
        AtLeastOneDigitOneSpecialCharacter
    }
    public class Password
    {
        private readonly string password;

        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string AlphaNumericLower = "0123456789abcdefghijklmnopqrstuvwxyz";
        private const string AlphaNumericWithUpperCase = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string AlphaNumericUpper = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string SpecialCharacters = " !#$%&'()*+,-./:;<=>?@[\"]^_`\\{|}~";
        private const string Numbers = "0123456789";
        #region Constructors
        public Password()
        {
            password = NewPassword(PasswordOptions.AtLeastOneDigitOneSpecialCharacter).ToString();
        }
        public Password(int length)
        {
            password = NewPassword(PasswordOptions.AtLeastOneDigitOneSpecialCharacter, length).ToString();
        }
        public Password(string str)
        {
            password = str;
        }
        public Password(PasswordOptions passOpt)
        {
            password = NewPassword(passOpt).ToString();
        }
        public Password(PasswordOptions passOpt, int length)
        {
            password = NewPassword(passOpt, length).ToString();
        }
#endregion
        public static Password NewPassword(PasswordOptions option, int length = 32)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var data = new byte[4];
                var d2 = new byte[4];
                rng.GetBytes(data);
                rng.GetBytes(d2);
                var seed = BitConverter.ToInt32(data, 0);
                var seed2 = BitConverter.ToInt32(d2, 0);
                var rnd = new Random(seed);
                var r2 = new Random(seed2);
                var passChars = new char[length];

                var sb = new StringBuilder();
                for (var i = 0; i < passChars.Length; i++)
                {
                    if (option == PasswordOptions.HasUpperCase) sb.Append(AlphaNumericWithUpperCase[rnd.Next(0, 62)]);
                    if (option == PasswordOptions.OnlyUpperCase) sb.Append(AlphaNumericUpper[rnd.Next(0, 36)]);
                    if (option == PasswordOptions.OnlyLowerCase) sb.Append(AlphaNumericLower[rnd.Next(0, 36)]);
                    if (option == PasswordOptions.OnlyAlphabet) sb.Append(Alphabet[rnd.Next(0, 52)]);
                    if (option == PasswordOptions.AtLeastOneDigitOneSpecialCharacter)
                    {
                        if (sb.Length == rnd.Next(sb.Length, length+1)) sb.Append(SpecialCharacters[rnd.Next(0, 33)]);
                        else if (sb.Length == r2.Next(sb.Length, length+1)) sb.Append(Numbers[rnd.Next(0, 10)]);
                        else sb.Append(Alphabet[rnd.Next(0,52)]);
                    }
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
