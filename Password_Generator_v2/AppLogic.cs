using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Generator_v2
{
    public class AppLogic
    {
        private Random _random;

        private string _password;
        private string letters = "abcdefghijklmnopqrstuvwxyzæøå";
        private string numbers = "123467890";
        private string symbols = "#¤%&@£$";        

        //Returns password 
        public string CreateNewPassword(bool uppercase, bool lowercase, bool numbers, bool symbols, int passwordlength)
        {
            if (!uppercase && !lowercase && !numbers && !symbols)
            {
                _password = "One checkbox must be checked!";
                return _password;
            }
            else
                return ScrablePassword(CombinePassword(uppercase, lowercase, numbers, symbols, passwordlength));
        }

        //Generates password
        private string CombinePassword(bool upper, bool lower, bool number, bool symbol, int passwordLgth)
        {
            _random = new Random();

            for (int i = 0; i < passwordLgth; i++)
            {
                if (upper)
                {
                    letters = letters.ToUpper();
                    _password += letters[_random.Next(0,letters.Length)];

                    if (_password.Length == passwordLgth) break;
                }

                if (lower)
                {
                    letters = letters.ToLower();
                    _password += letters[_random.Next(0, letters.Length)];

                    if (_password.Length == passwordLgth) break;
                }

                if (number)
                {
                    _password += this.numbers[_random.Next(0, this.numbers.Length)];

                    if (_password.Length == passwordLgth) break;
                }

                if (symbol)
                {
                    _password += this.symbols[_random.Next(0, this.symbols.Length)];

                    if (_password.Length == passwordLgth) break;
                }
                     
            }
            return _password;
        }

        //Scrable methode
        private string ScrablePassword(string word)
        {
            _random.Next();

            char[] chars = word.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                int j = _random.Next(chars.Length);

                char tmp = chars[i]; chars[i] = chars[j]; chars[j] = tmp;                
            }
            return new string(chars);
        }
    }
}
