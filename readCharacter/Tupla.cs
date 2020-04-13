using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace readCharacter
{
    class Tupla
    {
        const char ELEMENTS_SEPARATOR = ',';
        static string lettersConcat = "";
        public const string EMPTY_STRING = "";
        public const char SPACE = ' ';
        static bool valid = true;
        static Alfa alfa = new Alfa();

        public void addTupla()
        {
            Console.WriteLine("Please introduce a character from 0 to 9 or a to z, if you finish introduce +. This program allows maximum 3 characters");
            addChar();
            if(valid == true)
            {
                imprimir();
                metodoDeKleene();
            }
            

        }
        public static void addChar()
        {
            List<String> letra = new List<string>();
            for (int i=0; i<3; i++)
            {
                Console.Write("letra[" + (i + 1) + "]:");
                string palabra = Console.ReadLine();
                if (palabra.Trim() == "+")
                {
                    break;
                }
                else if (alfa.validateCharacter(palabra.Trim()) && palabra!="")
                {
                    letra.Add(palabra.Trim());
                }
                else
                {
                    Console.WriteLine("Caracter no permitido: " + palabra);
                    valid = false;
                    break;
                    
                }

            }
            letra.Sort();
            int numero = letra.Count();
            for(int i=1; i < numero; i++){
                if (letra[i-1] == letra[i])
                {
                    Console.WriteLine("Existe caracteres iguales");
                    valid = false;
                }
                
            }
            foreach (string palabras in letra)
            {
                if (alfa.validateCharacter(palabras.Trim()))
                {
                    addString(palabras.Trim());
                }
            }
        }

        public static void addString(string c)
        {
            lettersConcat += c+",";
        }

        public void imprimir()
        {
            lettersConcat = lettersConcat.Remove(lettersConcat.Length - 1);
            Console.WriteLine("σ = {" + lettersConcat + "}");
        }
        public void metodoDeKleene()
        {
            string[] kleene = lettersConcat.Split(ELEMENTS_SEPARATOR).Distinct().ToArray();
            int caracteres = kleene.Count();
            string klen="";
            int k;
            int j;
            int l;
            for (int i = 0; i < caracteres; i++)
            {
                klen += Convert.ToString(kleene[i]) + ",";
            }

            if (caracteres == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    klen += alfa.addString(Convert.ToString(kleene[0]))+",";
                }
            }

            else
            {

                for (l = 0; l < caracteres; l++)
                {
                    for (j = 0; j < caracteres; j++)
                    {
                        klen += Convert.ToString(kleene[l]);
                        klen += Convert.ToString(kleene[j]) + ",";
                    }


                }
                for (l = 0; l < caracteres; l++)
                {
                    for (j = 0; j < caracteres; j++)
                    {
                        for (k = 0; k < caracteres; k++)
                        {
                            klen += Convert.ToString(kleene[l]);
                            klen += Convert.ToString(kleene[j]);
                            klen += Convert.ToString(kleene[k]) + ",";
                        }
                    }


                }

            }
            /*else
            {
                for (l = 0; l < caracteres; l++)
                {
                    for (j = 0; j < caracteres; j++)
                    {
                        for (k = 0; k < caracteres; k++)
                        {
                            klen += Convert.ToString(kleene[l]);
                            klen += Convert.ToString(kleene[j]);
                            klen += Convert.ToString(kleene[k]) + ",";
                        }
                    }


                }
            }*/

            klen = klen.Remove(klen.Length - 1);
            Console.WriteLine("σ* = {Ø," + klen + "}");
        }

    }
}
