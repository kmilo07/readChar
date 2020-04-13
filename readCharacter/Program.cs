using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace readCharacter
{
    
    class Program
    {
        public static void Main(string[] args)
        {
            Menu();
            Console.ReadKey();
        }
        
        public static void Menu()
        {
            string caseSwitch;
            Console.WriteLine("Seleccione:\n    1) Para concatenar.\n    2) Para tupla.\n    3) Para grafos.");
            caseSwitch = Console.ReadLine();
            
            switch (caseSwitch)
            {
                case "1":
                    Alfa alfa = new Alfa();
                    alfa.addAlfa();
                    break;
                case "2":
                    Tupla tupla = new Tupla();
                    tupla.addTupla();
                    break;
                case "3":
                    Grafos grafo = new Grafos();
                    grafo.addGrafo();
                    break;
                default:
                    Console.WriteLine("La opción seleccionada no es valida");
                    Menu();
                    break;
            }
        }
        
    }

}
