/*Jose Francisco Estañon Miranda 70243
  Leslie Andrea Anguiano Reséndez 00000*/
using System;
using System.Linq;
using System.IO;

namespace Torres_de_Hanoi
{
    class Program
    {
        static void Main(string[] args) {
            Console.Write("\n\n\t\t\t\t\t\t¿Como te llamas?: ");
            string usuario = Console.ReadLine();

            Menu(usuario); }



        public static void Menu(string usuario)
        {
            if(File.Exists("marcador.txt") == false)
            {
                using (StreamWriter sw = File.AppendText("marcador.txt"))
                {
                    sw.Close();
                }
            }

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

            Console.WriteLine("\n\t\t\t\t\t\t1.- Instrucciones\t2.-Nueva Partida\t3.-Marcador\t4.-Salir");
            try
            {
                opc = int.Parse(Console.ReadLine());
            }
            catch (Exception) { Menu(usuario); }
            switch (opc){
                case 1:
                    try 
                    {
                        Instrucciones(usuario);
                    }catch (Exception) { Menu(usuario); }
                    break;

                case 2:
                    try
                    {
                        Console.Write("\n\t\t\t\t\t\t\t\t\t¿Con cuántos discos quieres jugar?: ");
                        int discos = int.Parse(Console.ReadLine());

                        if(discos == 0) { Console.WriteLine("\t\t\t\t\t\t\t\t\tReally?     -_- "); }

                        while(discos > 20) { 
                            Console.WriteLine("\t\t\t\t\t\t\t\t\tPor favor se razonable, esto dificultaria visualizarlo y ejecutarlo");
                            Console.WriteLine("\t\t\t\t\t\t\t\t\tIntentalo denuevo: ");
                            discos = int.Parse(Console.ReadLine());
                        }

                        int movimientos = 0;
                        int[,] Partida = Nuevo(discos);
                        Dibujar(Partida, discos, movimientos);
                        bool ganar;

                        do
                        {
                            movimientos++;
                            Partida = Juego(Partida, discos,movimientos);                 
                            ganar = Ganar(Partida, discos);
                        } while (ganar == false);
                        Felicidades(movimientos, discos, usuario);

                    }
                    catch (Exception) {
                        Console.WriteLine("\t\t\t\t\t\t\t\t\tVaya algo salio mal... De vuelta al Menu");
                        Console.WriteLine("\t\t\t\t\t\t\t\t\tPresiona enter...");
                        Console.ReadLine();
                        Menu(usuario); }
                    break;

                case 3:
                    try
                    {
                        Marcador(usuario);
                    }
                    catch (Exception) { Menu(usuario); }
                    break;

                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Menu(usuario);
                    break;
            }

        }
        public static void Instrucciones(string usuario)
        {

            Console.WriteLine("\n\t\t\t\t\t\t\t\t\tEl juego consiste en un número de discos perforados de radio creciente que se apilan \n\t\tinsertándose en uno de los tres postes fijados a un tablero. ");
            Console.WriteLine("\n\t\t\t\t\t   1  ");
            Console.WriteLine("\t\t\t\t\t  222 ");
            Console.WriteLine("\t\t\t\t\t 33333");
            Console.WriteLine("\t\t\t\t\t---|-------|-------|---");
            Console.WriteLine("\n\t\t\t\t\t\t\t\t\tPresione enter...");
            Console.ReadLine();

            Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\tEl objetivo del juego es trasladar la pila a otro de los postes siguiendo ciertas \n\t\treglas, como que NO SE PUEDE COLOCAR UN DISCO MÁS GRANDE ENCIMA DE UN DISCO MÁS PEQUEÑO. ");
            Console.WriteLine("\nPresione enter...");
            Console.ReadLine();

            Console.WriteLine("\n\t\t\t\t\t\t\t\t\tEl juego te pedira primero la columna de origen y luego la columna de destino");
            Console.WriteLine("\n\t\t\t\t\t\t\t\t\tPresione enter...");
            Console.ReadLine();

            Console.WriteLine("\n\t\t\t\t\t\t\t\t\tEso seria todo, ¿listo para jugar?");
            Console.WriteLine("\n\t\t\t\t\t\t\t\t\tPresione enter...");
            Menu(usuario);
        }
        public static void Dibujar(int[,] H, int discos, int movimientos)
        {
            Console.WriteLine("\n\t\t\t\t\t\t\t\t\tMovimientos: " + movimientos + "\n");
            for (int j = 0; j < discos; j++)
            {
                Console.Write("\t\t\t\t\t\t\t\t\t");
                for (int i = 0; i < 3; i++)
                {
                    if (H[j, i] != 0)
                    {
                        for (int k = 0; k < (discos - H[j,i]); k++) { Console.Write(" "); } // Separacion izquierda

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
            Console.Write("\t\t\t\t\t\t\t\t\t");
            Console.Write(string.Concat(Enumerable.Repeat("-", 2 * (3*discos + 1) + 1)));
        }
        public static int[,] Nuevo(int discos)
        {
            int[,] H = new int[discos,3];

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < discos; i++)
                {
                   if(j == 0)
                    {
                        H[i, j] = i + 1;
                    }
                    else { H[i, j] = 0; }
                }
            }
            return (H);
        }
        public static int[,] Juego(int[,]H, int discos, int movimientos)
        {
            Console.Write("\n\t\t\t\t\t\t\t\t\tColumna de origen: ");
            int C_orig = int.Parse(Console.ReadLine()) - 1;
            Console.Write("\n\t\t\t\t\t\t\t\t\tColumna de destino: ");
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
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\tEse es un movimiento ilegal");   // Muestra si se puede *Evitar que cuente
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
                        Console.WriteLine("\t\t\t\t\t\t\t\t\tEn esa columna no hay nada! ");
                        break;
                    }
                }
            }
            else { Console.WriteLine("\t\t\t\t\t\t\t\t\t No tiene mucho sentido mover a la misma columna");}
            // ** termina logica del juego ** 

            Dibujar(H, discos,movimientos);
            return (H);
        }
        public static Boolean Ganar(int[,] H, int discos)
        {
            for(int i = 0; i < discos; i++)
            {
               if(H[i,2] != (i + 1)) 
                {
                    return false;
                }
            }
            return true;
        }
        public static void Felicidades(int movimientos, int discos, string usuario)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int optimo = (int)Math.Pow(2, discos) - 1;
            
            Console.WriteLine("\n\n\t\t\t\t\t`7MM***YMM          `7MM    db             db       `7MM                `7MM                    OO   ");
            Console.WriteLine("\t\t\t\t\t  MM    `7            MM                              MM                  MM                    88   ");
            Console.WriteLine("\t\t\t\t\t  MM   d    .gP*Ya    MM  `7MM   ,p6*bo  `7MM    ,M**bMM   ,6*Yb.    ,M**bMM   .gP*Ya   ,pP*Ybd  ||  ");
            Console.WriteLine("\t\t\t\t\t  MM**MM   ,M'   Yb   MM    MM  6M'  OO    MM, AP     MM  8)   MM  ,AP    MM, M'    Yb  8I   `*  ||  ");
            Console.WriteLine("\t\t\t\t\t  MM   Y   8M******   MM    MM  8M         MM  8MI    MM   ,pm9MM  8MI    MM  8M******  `YMMMa.  `'  ");
            Console.WriteLine("\t\t\t\t\t  MM       YM.    ,   MM    MM  YM.    ,   MM  `Mb    MM  8M   MM  `Mb    MM  YM.    ,  L.   I8  ,,  ");
            Console.WriteLine("\t\t\t\t\t.JMML.      `Mbmmd' .JMML..JMML. YMbmd'  .JMML. `Wbmd*MML.`Moo9^Yo. `Wbmd*MML. `Mbmmd'  M9mmmP'  db  ");

            Console.WriteLine("\n\t\t\t\t\t\t\t\t\t"+ usuario + " hiciste: " + movimientos + " movimientos");
            Console.WriteLine("\t\t\t\t\t\t\t\t\tEl minimo número de movimietos es: " + optimo);
            Console.WriteLine("\t\t\t\t\t\t\t\t\tPresione enter...");
            Console.ReadLine();

            if (movimientos == optimo) {

                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t           cccccccccccccc       ");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t           c ccccccccccc c      ");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t         c    ccccccccc    c    ");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t            c  ccccccc  c       ");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t                cccc            ");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t                 cc             ");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t           cccccccccccccc       ");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t           cccccccccccccc       ");

                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t!Felicidades " + usuario + " lograste un buen puntuaje!");
                Console.ReadLine();

                int guardar;
                Console.WriteLine("\t\t\t\t\t\t\t\t\t¿Quieres guardar tu puntuación?\n\t\t\t\t\t\t\t\t\t1.-Sí\t2.-No");
                guardar = int.Parse(Console.ReadLine());
                if (guardar == 1)
                {
                    string linea = usuario + "\tMovimientos: " + movimientos + "\tDiscos: "+ discos + "\tFecha: " +  DateTime.Today;
                    using (StreamWriter sw = File.AppendText("marcador.txt"))
                    {
                        sw.WriteLine(linea);
                        sw.Close();
                    }

                    Console.WriteLine("\t\t\t\t\t\t\t\t\tSe ha guardado exitosamente");
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\tPresione enter...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\tPresione enter...");
                    Console.ReadLine();
                }                
            }
            Menu(usuario);
        }
        public static void Marcador(string ususario)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("\n\n\t\t\t\t\t                                                           ,,                              ccccccccccccccc");
            Console.WriteLine("\t\t\t\t\t  7MMM.    ,MMF                                          `7MM                             c  ccccccccccc  c");
            Console.WriteLine("\t\t\t\t\t  MMMb     PMM                                             MM                             c   ccccccccc   c");
            Console.WriteLine("\t\t\t\t\t  M YM,   M MM   ,6'Yb.  `7Mb,od8  ,p6'bo   ,6'Yb.    ,MMCbMM   ,pW'Wq.  `7Mb,od8           c  ccccccc  c");
            Console.WriteLine("\t\t\t\t\t  M  Mb  M' MM  8)   MM    MM'    6M   OO  8)   MM  ,AP    MM  6W'    Wb   MM   '               cccc");
            Console.WriteLine("\t\t\t\t\t  M  YM.P'  MM   ,pm9MM    MM     8M        ,pm9MM  8MI    MM  8M     M8   MM                    cc");
            Console.WriteLine("\t\t\t\t\t  M  `YM'   MM  8M   MM    MM     YM.    , 8M   MM  `Mb    MM  YA.   ,A9  MM               cccccccccccccc");
            Console.WriteLine("\t\t\t\t\t.JML. `'  .JMML.`Moo9^Yo..JMML.    YMbmd'  `Moo9 ^ Yo. `Wbmd' MM'Ybmd9'.JMML.              cccccccccccccc");

            string linea;
            using (StreamReader sr = new StreamReader("marcador.txt"))
            {
                linea = sr.ReadToEnd();
                Console.WriteLine(linea);
                sr.Close();
            }

            Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\tPresione enter...");
            Console.ReadLine();
            Menu(ususario);

        }

    }
} 