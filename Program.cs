using System;
using System.IO;

namespace MPS_30_EJ08
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {

            int opcion = 0;
            double numero;
            int repetir;
           
                Console.WriteLine("Elija una opción: \n1.- Crear Archivo\t2.-Agregar datos\t3.-Mostrar datos\t4.-Sumatoria");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        try
                        {
                            generarArchivo();
                            Console.WriteLine("Archivo vreado");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ocurrió un error al crear el archivo " + ex.Message);
                        }
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("Ingrese el número ");
                            numero = double.Parse(Console.ReadLine());
                            agregarInfo(numero);
                            Console.WriteLine("Numero agregado");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ocurrió un error al agregar el numero" + ex.Message);
                        }
                        break;
                        break;
                    case 3:
                        try
                        {
                            leerArchivo();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ocurrió un error al leer el archivo " + ex.Message);
                        }
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("El resultado de la sumatoria es: " + Sumatoria());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ocurrio un error al hacer la sumatoria " + ex.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("OPCION NO VALIDA");
                        break;
                }
                Console.WriteLine("Desea hacer otra acción?" + "1.-Si");
                repetir = int.Parse(Console.ReadLine());
            
            if (repetir == 1)
            {
                Menu();
            }
                
        }

        public static void generarArchivo()
        {
            string archivo = "fuente.txt";
            string texto = "LISTA DE NUMEROS";
            using (StreamWriter sw = File.AppendText(archivo))
            {
                sw.WriteLine(texto);
                sw.Close();
            }
        }
        public static void agregarInfo(double _n)
        {
            string archivo = "fuente.txt";
            double linea = _n;
            using (StreamWriter sw = File.AppendText(archivo))
            {
                sw.WriteLine(linea);
                sw.Close();
            }

        }
        public static void leerArchivo()
        {
            string archivo = "fuente.txt";
            string linea = "";
            using (StreamReader sr = new StreamReader(archivo))
            {
                linea = sr.ReadToEnd();
                Console.WriteLine(linea);
                sr.Close();
            }

        }
        public static double Sumatoria()
        {
            string archivo = "fuente.txt";
            string linea = "";
            double sumatoria = 0;
            int contador = 0;

            using (StreamReader sr = new StreamReader(archivo))
            {
                while((linea = sr.ReadLine()) != null)
                {
                    if(contador == 0)
                    {
                        //linea = sr.ReadLine();
                    }

                    else
                    {
                      //linea = sr.ReadLine();
                      sumatoria += double.Parse(linea);
                    }

                    contador++;
                }

                sr.Close();
                return sumatoria;
            }
        }

    }

}
