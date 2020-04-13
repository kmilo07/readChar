using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace readCharacter
{
    class Alfa
    {
        static string lettersConcat = "";
        static string lettersBad = "";
        const char ELEMENTS_SEPARATOR = ',';

        public void addAlfa()
        {
            string letter;
            Console.WriteLine("Please introduce a character from 0 to 9 or a to z and separated by commas");
            letter = Console.ReadLine();
            addChar(letter);
            imprimir();
            
        }
        public bool validateCharacter(string a)
        {
            String estructura = "^(([a-z]{1})|([0-9]{1}))$";
            return Regex.IsMatch(a, estructura);

        }
        public void addChar(string word)
        {
            string[] palabra = word.Split(ELEMENTS_SEPARATOR).Distinct().ToArray();

            foreach (string palabras in palabra)
            {
                if (validateCharacter(palabras.Trim()))
                {
                    addString(palabras.Trim());
                }
                else
                {
                    addStringError(palabras.Trim());
                }
            }

        }

        public string addString(string c)
        {
            return lettersConcat += c;
        }
        public static void addStringError(string c)
        {
            lettersBad += c + ",";
        }
        public void imprimir()
        {
            if (lettersConcat.Equals(""))
            {
                Console.WriteLine("No valid letter");
                Console.WriteLine("The letters invalid are: " + lettersBad);

            }
            else if (lettersBad.Equals(""))
            {
                Console.WriteLine("The letters valid are:  " + lettersConcat);
            }
            else
            {
                Console.WriteLine("The letters valid are:  " + lettersConcat);
                Console.WriteLine("The letters invalid are: " + lettersBad);

            }
        }
        public void imprimirTupla()
        {
            Console.WriteLine("Ø" + lettersConcat);
        }
    }
}
