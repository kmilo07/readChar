using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace readCharacter
{
    class Grafos
    {
        const char ELEMENTS_SEPARATOR = ',';
        static bool dirigido;
        static int numeroDeNodos;
        static int trayectorias;
        public void addGrafo()
        {
            string indicador;
            Console.WriteLine("Seleccione una de las siguientes opciones.\n     1) Si es dirigido.\n     2) Si no es dirigido.");
            indicador = Console.ReadLine();
            readIndex(indicador);
            Imprimir();
            Console.ReadKey();



        }

        public void readIndex(string r)
        {
            switch (r)
            {
                case "1":
                    grafoDirigido();
                    break;
                case "2":
                    grafoNoDirigido();
                    break;
                default:
                    Console.WriteLine("La opción seleccionada " + r + " no es valida, por favor ingrese una valida.");
                    addGrafo();
                    break;
            }
        }

        public void grafoDirigido()
        {
            Console.WriteLine("Elegió un grafo dirigido\n Ingrese los valores las posiciones\n los numeros deben estar separador por una coma(,)");
            dirigido = true;
            CargarMatriz();
            readTrayectorias();
            TrayectoriaDirigida();
            
        }



        public void grafoNoDirigido()
        {
            Console.WriteLine("Eligió un grafo no dirigido");
            dirigido = false;
            CargarMatriz();
            readTrayectorias();
            TrayectoriaDirigida();
            
        }

        public bool validateNumber(string a)
        {
            String estructura = "^([0-9]{1},[0-9]{1})$";
            return Regex.IsMatch(a, estructura);

        }

        public bool validateArista(string a)
        {
            String estructura = "^([1-5]{1}->[1-5]{1})$";
            return Regex.IsMatch(a, estructura);
        }
        public void readGrafo()
        {
            Console.WriteLine("Cuantos nodos desea agregar(max 5): ");
            numeroDeNodos = Convert.ToInt32(Console.ReadLine());
            if (numeroDeNodos > 5)
            {
                
                Console.WriteLine("La cantidad es superior a la permitida, por favor ingrese un valor igual a (5) o inferior");
                readGrafo();
            }
            else { 
            mat = new String[numeroDeNodos];
            Console.WriteLine("Ingrese vertices:");

            for (int i = 0; i < numeroDeNodos; i++)
            {
                int f;
                int c;
                Console.Write(i + 1 + ")");
                string leer = Console.ReadLine();
                if (leer != "+")
                {
                    if (validateNumber(leer))
                    {
                        mat[i] = leer;
                        string[] numero = leer.Split(ELEMENTS_SEPARATOR).ToArray();
                        f = Convert.ToInt32(numero[0]);
                        c = Convert.ToInt32(numero[1]);
                        matr[f + 1, c + 1] += "(" + (i + 1) + ")";
                    }
                    else
                    {
                        Console.WriteLine("Caracter invalido");
                        break;
                    }
                }
                else
                {
                    break;
                }

            }
            }
        }



        public string[,] matr;
        public string[] mat;
        public string[] tray;
        public string[] tra;
        

        public void CargarMatriz()
        {

            int filas = 11;
            int columnas = 11;
            matr = new string[filas, columnas];
            int f = 0;
            int c = 0;
            for (c = 0; c < 11; c++)
            {
                matr[f, c] = "" + (c - 1);
            }

            for (f = 0, c = 0; f < 11; f++)
            {
                matr[f, c] = "" + (f - 1);
            }

            matr[0, 0] = " ";
            readGrafo();
        }

        public void readTrayectorias()
        {
            double trayectoriasPermitdas;
            trayectoriasPermitdas = (Math.Log10(numeroDeNodos) / Math.Log10(2));
            trayectorias = Convert.ToInt32(trayectoriasPermitdas);            
            tray = new string[trayectorias];
            Console.WriteLine("Ingrese aristas");
            string arista;
            for (int i = 0; i < trayectorias; i++)
            {
                arista = Console.ReadLine();
                if (validateArista(arista))
                {
                    if (existe(arista))
                    {
                        tray[i] = arista;
                    }
                    else
                    {
                        Console.WriteLine("No se encuentra uno de las nodos mencionados");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("La arista no existe");
                    break;
                }
            }


        }

        public bool existe(string c)
        {
            bool siExiste = false;
            string[] tra = c.Split('-', '>').ToArray();
            int f;
            int co;
            f = Convert.ToInt32(tra[0]);//inicio
            co = Convert.ToInt32(tra[2]);//fin
            if (mat[f - 1] != null && mat[co - 1] != null)
            {
                siExiste = true;
            }
            else
            {
                siExiste = false;
            }
            return siExiste;
        }

        private void TrayectoriaDirigida()
        {
            string leer;
            for (int i = 0; i < trayectorias; i++)
            {
                leer = tray[i].ToString();
                conversionDeTrayectoria(leer);
            }
        }

        private void conversionDeTrayectoria(string c)
        {
            string[] tra = c.Split('-', '>').ToArray();
            int f;
            int co;
            f = Convert.ToInt32(tra[0]);//inicio
            co = Convert.ToInt32(tra[2]);//fin
            string primerNodo = mat[f - 1];  //(x,y)
            string segundoNodo = mat[co - 1]; //(w,z)
            string[] numero1 = primerNodo.Split(ELEMENTS_SEPARATOR).ToArray();
            int f1 = Convert.ToInt32(numero1[0]);    //Nodo de inicio
            int col1 = Convert.ToInt32(numero1[1]);  //Inicia el desplazamiento 
            string[] numero2 = segundoNodo.Split(ELEMENTS_SEPARATOR).ToArray();
            int f2 = Convert.ToInt32(numero2[0]);      //Nodo final
            int col2 = Convert.ToInt32(numero2[1]);    //Termina el desplazamiento
            int desplazamientoEnY = f2 - f1;  //matr[fila,columna]   matr[desplazamientoY,desplazamientoX]
            int desplazamientoEnX = col2 - col1;
            if (dirigido == true)
            {
                if (desplazamientoEnX > 0)
                {
                    matr[f1 + 1, col1 + 1] = "(" + f + ")o";
                    matr[f2 + 1, col2 + 1] = ">(" + co + ")";
                }
                else if (desplazamientoEnX < 0)
                {
                    matr[f1 + 1, col1 + 1] = "o(" + f + ")";
                    matr[f2 + 1, col2 + 1] = "(" + co + ")<";
                }
                else if (desplazamientoEnX == 0)
                {
                    if (desplazamientoEnY < 0)
                    {
                        matr[f1 + 1, col1 + 1] = "(" + f + ")o";
                        matr[f2 + 1, col2 + 1] = "^(" + co + ")";
                    }
                    else
                    {
                        matr[f1 + 1, col1 + 1] = "(" + f + ")o";
                        matr[f2 + 1, col2 + 1] = "v(" + co + ")";
                    }
                }
            }
            else if (dirigido == false)
            {
                if (desplazamientoEnX > 0)
                {
                    matr[f1 + 1, col1 + 1] = "(" + f + ")o";
                    matr[f2 + 1, col2 + 1] = "o(" + co + ")";
                }
                else if (desplazamientoEnX < 0)
                {
                    matr[f1 + 1, col1 + 1] = "o(" + f + ")";
                    matr[f2 + 1, col2 + 1] = "(" + co + ")o";
                }
                else if (desplazamientoEnX == 0)
                {
                    if (desplazamientoEnY < 0)
                    {
                        matr[f1 + 1, col1 + 1] = "(" + f + ")o";
                        matr[f2 + 1, col2 + 1] = "o(" + co + ")";
                    }
                    else
                    {
                        matr[f1 + 1, col1 + 1] = "(" + f + ")o";
                        matr[f2 + 1, col2 + 1] = "o(" + co + ")";
                    }
                }
            }
            while (desplazamientoEnX !=0 || desplazamientoEnY!=0)
            {
                f2 += 1;  //Ya que la matriz comienza en 0 se le debe añadir 1 para que ubique bien
                f1 += 1;
                col1 += 1;
                col2 += 1;
                int desplazamientoDeColumna = Math.Abs(desplazamientoEnX);
                int desplazamientoDeFila = Math.Abs(desplazamientoEnY);
                int deplazamiento = Math.Abs(desplazamientoDeColumna - desplazamientoDeFila);
                if (desplazamientoEnX == 0) //desplazamientoEnY tiene que aumentar o disminuir y desplazamientoEnX constante
                {
                    if (desplazamientoEnY > 0) //desplazamientoEnY tiene que aumentar
                    {
                        for (int i = f1; i < f2; i++)
                        {
                            if (i + 1 == f2)
                            {
                                desplazamientoEnY--;
                                break;                                
                            }
                            else
                            {
                                matr[(i + 1), col1] += ".";
                            }
                            desplazamientoEnY--;
                        }

                    }

                    else     //desplazamiento tiene que bajar; 
                    {
                        for (int i = f1; i > f2; i--)
                        {
                            if (i - 1 == f2)
                            {
                                desplazamientoEnY++;
                                break;                                
                            }
                            else
                            {
                                matr[(i - 1), col1] += ".";
                            }
                            desplazamientoEnY++;
                        }
                    }


                }

                else if (desplazamientoEnY == 0) //desplazamientoEnX tiene que aumentar o disminuir y desplazamientoY constante
                {
                    if (desplazamientoEnX > 0)
                    {
                        for (int i = col1; i < col2; i++)
                        {
                            if (i + 1 == col2)
                            {
                                desplazamientoEnX--;
                                break;                                
                            }
                            else
                            {
                                matr[f1, (i + 1)] += ".";
                            }
                            desplazamientoEnX--;
                        }
                    }
                    else
                    {
                        for (int i = col1; i > col2; i--)
                        {
                            if (i - 1 == col2)
                            {
                                desplazamientoEnX++;
                                break;                                
                            }
                            else
                            {
                                matr[f1, (i - 1)] += ".";
                            }
                            desplazamientoEnX++;
                        }
                    }

                }

                /////Cuando los valore son distintos desde acá hay un problema--------------------------------------------------------------------------------
                
                else 
                {
                    
                    if (desplazamientoDeColumna > desplazamientoDeFila)  //movemos el desplazamiento en el filas
                    {
                        
                        if (desplazamientoEnX > 0)              //matr[fila,columna]   matr[desplazamientoY,desplazamientoX]
                        {
                            for(int i=0; i < deplazamiento; i++)
                            {
                                col1 += 1;
                                f1 += 1;
                                matr[f1 + 1, col1 + 1] += ".";
                                desplazamientoEnX -= 1;
                            }
                           
                        }
                        else
                        {
                            for (int i = 0; i < deplazamiento; i++)
                            {
                                col1 -= 1;
                                matr[f1 + 1, col1 + 1] += ".";
                                desplazamientoEnX += 1;
                            }
                                
                        }
                    }
                    else if(desplazamientoDeColumna == desplazamientoDeFila)  //movemos el desplazamiento en las columnas
                    {
                        
                        if (desplazamientoEnY < 0 && desplazamientoEnX < 0)
                        {
                            for (int i = 0; i < desplazamientoDeColumna; i++)
                            {
                                
                                f1 -= 1;
                                col1 -= 1;
                                matr[f1, col1] += ".";
                                desplazamientoEnX += 1;
                                desplazamientoEnY += 1;
                                
                            }
                                
                        }
                        else if(desplazamientoEnY <0 && desplazamientoEnX >0)
                        {
                            for (int i = 0; i < desplazamientoDeColumna; i++)
                            {
                                f1 -= 1;
                                col1 += 1;
                                matr[f1, col1] += ".";
                                desplazamientoEnX -= 1;
                                desplazamientoEnY += 1;
                                
                            }
                                
                        }
                        else if(desplazamientoEnX<0 && desplazamientoEnY > 0)
                        {
                            for (int i = 0; i < desplazamientoDeColumna; i++)
                            {
                                f1 += 1;
                                col1 -= 1;
                                matr[f1, col1] += ".";
                                desplazamientoEnX += 1;
                                desplazamientoEnY -= 1;
                                
                            }
                        }
                        else
                        {
                            for (int i = 0; i < desplazamientoDeColumna; i++)
                            {
                                f1 += 1;
                                col1 += 1;
                                matr[f1, col1] += ".";
                                desplazamientoEnX -= 1;
                                desplazamientoEnY -= 1;
                                
                            }
                        }
                    }
                    else
                    {
                        if (desplazamientoEnY > 0)
                        {
                            for (int i = 0; i < deplazamiento; i++)
                            {
                                f1 += 1;
                                matr[f1 + 1, col1 + 1] += ".";
                                desplazamientoEnY -= 1;
                            }

                        }
                        else
                        {
                            for (int i = 0; i < deplazamiento; i++)
                            {
                                f1 -= 1;
                                matr[f1 + 1, col1 + 1] += ".";
                                desplazamientoEnY += 1;
                            }

                        }
                    }
                   
                }

            }

        }

        public void Imprimir()
        {

            for (int f = 0; f < matr.GetLength(0); f++)
            {
                for (int c = 0; c < matr.GetLength(1); c++)
                {
                    Console.Write(matr[f, c] + "     ");
                }
                Console.WriteLine();
            }
        }

    }
}
