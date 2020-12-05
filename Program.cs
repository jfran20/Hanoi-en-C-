/*Jose Francisco Estañón Miranda 70243
  Leslie Andrea Anguiano Reséndez 70930*/
using System;
using System.Linq;
using System.IO;

namespace Torres_de_Hanoi
{
    class Program
    {
        static void Main(string[] args) { Menu(); }



        public static void Menu()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            int opc = 2;
            Console.Clear();
            
            Console.WriteLine("\n\n\t\tMMP**MM**YMM                                                       `7MM               `7MMF'  `7MMF'                                    db  ");
            Console.WriteLine("\t\tP'   MM   `7                                                         MM                 MM      MM                                          ");
            Console.WriteLine("\t\t     MM       ,pW*Wq.  `7Mb,od8 `7Mb,od8  .gP*Ya  ,pP*Ybd       ,M**bMM   .gP*Ya        MM     MM   ,6*Yb.     `7MMpMMMb.   ,pW*Wq.   `7MM  ");
            Console.WriteLine("\t\t     MM      6W'   `Wb   MM' *'   MM' *' ,M'   Yb 8I   `*     ,AP    MM  ,M'   Yb       MMmmmmmmMM  8)   MM      MM    MM  6W'   `Wb    MM  ");
            Console.WriteLine("\t\t     MM      8M     M8   MM       MM     8M****** `YMMMa.     8MI    MM  8M******       MM      MM   ,pm9MM      MM    MM  8M     M8    MM  ");
            Console.WriteLine("\t\t     MM      YA.   ,A9   MM       MM     YM.    , L.   I8     `Mb    MM  YM.    ,       MM      MM  8M   MM      MM    MM  YA.   ,A9    MM  ");
            Console.WriteLine("\t\t   .JMML.     `Ybmd9'  .JMML.   .JMML.    `Mbmmd' M9mmmP'      `Wbmd*MML. `Mbmmd'     .JMML.  .JMML.`Moo9 ^ Yo..JMML  JMML. `Ybmd9'   .JMML.");


            Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t¡Bienvenido!");
            Console.WriteLine("\n\t\t\t\t\t\t1.- Instrucciones\t2.-Nueva Partida\t3.-Marcador\t4.-Salir");
            try
            {
                opc = int.Parse(Console.ReadLine());
            }
            catch (Exception) { Menu(); }
            switch (opc)
            {
                case 1:
                    try
                    {
                        Console.Clear();
                        Instrucciones();
                    }
                    catch (Exception Ex) { Menu(); }
                    break;

                case 2:
                    try
                    {
                
                        Console.WriteLine("\t\t\t¿Con cuántos discos quieres jugar?");
                        Console.WriteLine("\t\t\tFunciono mejor con valores menores a 10: ");
                        int discos = int.Parse(Console.ReadLine());

                        if (discos == 0) { Console.WriteLine("\t\t\tReally?     -_- "); }

                        while (discos > 20)
                        {
                            Console.WriteLine("\t\t\tPor favor se razonable, esto dificultaría visualizarlo y ejecutarlo");
                            Console.WriteLine("\t\t\tInténtalo de nuevo: ");
                            discos = int.Parse(Console.ReadLine());
                        }

                        int movimientos = 0;
                        int[,] Partida = Nuevo(discos);
                        Dibujar(Partida, discos, movimientos);
                        bool ganar;

                        do
                        {
                            movimientos++;
                            Partida = Juego(Partida, discos, movimientos);
                            ganar = Ganar(Partida, discos);
                        } while (ganar == false);
                        Felicidades(movimientos, discos);

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\t\t\tVaya algo salió mal... De vuelta al Menú");
                        Console.WriteLine("\tPresiona enter...");
                        Console.ReadLine();
                        Menu();
                    }
                    break;

                case 3:
                    try
                    {
                        Marcador();
                        Console.WriteLine("\tPresiona enter...");
                        Console.ReadLine();
                        Menu();
                    }
                    catch (Exception Ex) { Menu(); }
                    break;

                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Menu();
                    break;
            }

        }
        public static void Instrucciones()
        {

            Console.WriteLine("\n\t\tEl juego consiste en un número de discos perforados de radio creciente que se apilan \n\t\tinsertándose en uno de los tres postes fijados a un tablero. ");
            Console.WriteLine("\n\t\t\t\t\t   1  ");
            Console.WriteLine("\t\t\t\t\t  222 ");
            Console.WriteLine("\t\t\t\t\t 33333");
            Console.WriteLine("\t\t\t\t\t---|-------|-------|---");
            Console.WriteLine("\n\tPresione enter...");
            Console.ReadLine();

            Console.WriteLine("\n\n\t\tEl objetivo del juego es trasladar la pila a otro de los postes siguiendo ciertas \n\t\treglas, como que NO SE PUEDE COLOCAR UN DISCO MÁS GRANDE ENCIMA DE UN DISCO MÁS PEQUEÑO. ");
            Console.WriteLine("\n\tPresione enter...");
            Console.ReadLine();

            Console.WriteLine("\n\t\tEl juego te pedirá primero la columna de origen y luego la columna de destino");
            Console.WriteLine("\n\ttPresione enter...");
            Console.ReadLine();

            Console.WriteLine("\nEso sería todo, ¿listo para jugar?");
            Console.WriteLine("\n\tPresione enter...");
            Menu();
        }
        public static void Dibujar(int[,] H, int discos, int movimientos)
        {
            Console.WriteLine("\nMovimientos: " + movimientos + "\n");
            for (int j = 0; j < discos; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (H[j, i] != 0)
                    {
                        for (int k = 0; k < (discos - H[j, i]); k++) { Console.Write(" "); } // Separacion izquierda

                        string pieza = string.Concat(Enumerable.Repeat(H[j, i], 2 * (H[j, i] + 1) - 1)); // Numeros
                        Console.Write(pieza);

                        int faltante = (2 * discos) - (((discos - H[j, i]) + (2 * (H[j, i] + 1) - 1))); // Completa la forma
                        for (int k = 0; k < faltante + 1; k++) { Console.Write(" "); }
                    }

                    else
                    {
                        for (int k = 0; k < 2 * discos + 1; k++) { Console.Write(" "); } // En caso de que no haya nada 
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 2 * (3 * discos + 1))));
        }
        public static int[,] Nuevo(int discos)
        {
            int[,] H = new int[discos, 3];

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < discos; i++)
                {
                    if (j == 0)
                    {
                        H[i, j] = i + 1;
                    }
                    else { H[i, j] = 0; }
                }
            }
            return (H);
        }
        public static int[,] Juego(int[,] H, int discos, int movimientos)
        {
            Console.WriteLine("Columna de origen: ");
            int C_orig = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Columna de destino: ");
            int C_dest = int.Parse(Console.ReadLine()) - 1;


            // *** Logica del juego ***
            if (C_orig != C_dest)
            {
                for (int i = 0; i < discos; i++)                                            // Itera en todas las filas
                {
                    if (H[i, C_orig] != 0)                                                  // Busca el Primer disco 
                    {
                        for (int j = discos - 1; j >= 0; j--)                               // Itera en la columna destino de abajo hacia arriba
                        {
                            if (H[j, C_dest] == 0)                                          // Busca un espacio libre 
                            {
                                if (j < discos - 1)                                         // Si no es el unico disco
                                {
                                    if (H[i, C_orig] > H[j + 1, C_dest])                    // Compara con el de abajo 
                                    {
                                        Console.WriteLine("Ese es un movimiento ilegal");   // Muestra si se puede *Evitar que cuente
                                        break;
                                    }
                                    else                                                    // Realiza el cambio
                                    {
                                        H[j, C_dest] = H[i, C_orig];
                                        H[i, C_orig] = 0;
                                        break;
                                    }
                                }
                                else
                                {
                                    H[j, C_dest] = H[i, C_orig];
                                    H[i, C_orig] = 0;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                    else if (i == (discos - 1)) // Si no encuentra nada sale *Evitar que cuente*
                    {
                        Console.WriteLine("¡En esa columna no hay nada! ");
                        break;
                    }
                }
            }
            else { Console.WriteLine("\t\t\t No tiene mucho sentido mover a la misma columna..."); }
            // ** termina logica del juego ** 

            Dibujar(H, discos, movimientos);
            return (H);
        }
        public static Boolean Ganar(int[,] H, int discos)
        {
            for (int i = 0; i < discos; i++)
            {
                if (H[i, 2] != (i + 1))
                {
                    return false;
                }
            }
            return true;
        }


        public static void Felicidades(int movimientos, int discos)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int optimo = (int)Math.Pow(2, discos) - 1;

            Console.WriteLine("\n\n\t\t\t\t   `7MM***YMM          `7MM    db             db       `7MM                `7MM                     OO   ");
            Console.WriteLine("\t\t\t\t     MM    `7            MM                              MM                  MM                     88   ");
            Console.WriteLine("\t\t\t\t     MM   d    .gP*Ya    MM  `7MM   ,p6*bo  `7MM    ,M**bMM   ,6*Yb.    ,M**bMM   .gP*Ya   ,pP*Ybd  ||  ");
            Console.WriteLine("\t\t\t\t     MM**MM   ,M'   Yb   MM    MM  6M'  OO    MM, AP     MM  8)   MM  ,AP    MM, M'    Yb  8I   `*  ||  ");
            Console.WriteLine("\t\t\t\t     MM   Y   8M******   MM    MM  8M         MM  8MI    MM   ,pm9MM  8MI    MM  8M******  `YMMMa.  `'  ");
            Console.WriteLine("\t\t\t\t     MM       YM.    ,   MM    MM  YM.    ,   MM  `Mb    MM  8M   MM  `Mb    MM  YM.    ,  L.   I8  ,,  ");
            Console.WriteLine("\t\t\t\t   .JMML.      `Mbmmd' .JMML..JMML. YMbmd'  .JMML. `Wbmd*MML.`Moo9^Yo. `Wbmd*MML. `Mbmmd'  M9mmmP'  db  ");

            Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t   ¡Lo lograste!");

            Console.WriteLine("\n\n\t\t\t\t\t\t\t\t       Hiciste: " + movimientos + " movimientos");
            Console.WriteLine("\n\n\t\t\t\t\t\t\t        El mínimo número de movimietos es: " + optimo);
            Console.WriteLine("\tPresione enter...");
            Console.ReadLine();

            if (movimientos == optimo)
            {

                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t           cccccccccccccc       ");
                Console.WriteLine("\t\t\t\t\t\t\t\t           c ccccccccccc c      ");
                Console.WriteLine("\t\t\t\t\t\t\t\t         c    ccccccccc    c    ");
                Console.WriteLine("\t\t\t\t\t\t\t\t            c  ccccccc  c       ");
                Console.WriteLine("\t\t\t\t\t\t\t\t                cccc            ");
                Console.WriteLine("\t\t\t\t\t\t\t\t                 cc             ");
                Console.WriteLine("\t\t\t\t\t\t\t\t           cccccccccccccc       ");
                Console.WriteLine("\t\t\t\t\t\t\t\t           cccccccccccccc       ");

                Console.WriteLine("\n\t\t\t\t\t\t\t      !Felicidades, lograste un buen puntuaje!");
                Console.ReadLine();

                


                Console.WriteLine("\n\n\tPresione enter...");
                Console.ReadLine();
            }

            AgregarInfo(movimientos);
            Console.ReadLine();
            Menu();
        }

        public static void Marcador()
        {
            LeerArchivo();
        }

        public static void AgregarInfo(int _movimientos)//se va a agregar el número que nos pasen al .txt
        {
            string archivo = "marcador.txt";
            string usuario = "";

            Console.WriteLine("\t\t\tIngresa un nombre de usuario para que tus movimientos se guarden en el marcador");
            usuario = Console.ReadLine();

            using (StreamWriter sw = File.AppendText(archivo))//el "AppendText" no sobre escribe 
            {
                sw.WriteLine(usuario + "..................." + _movimientos );
                
                sw.Close();
            }
        }

        public static void LeerArchivo()
        {
            string archivo = "marcador.txt";
            string linea = "";

            using (StreamReader sr = new StreamReader(archivo))
            {
                
                linea = sr.ReadToEnd();
                Console.WriteLine(linea);
                sr.Close();
            }
        }
    }
}
