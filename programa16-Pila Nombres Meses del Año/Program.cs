using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace programa16_Pila_Nombres_Meses_del_Año
{
    internal class Program
    {
        class Pilas
        {
            //campos de la clase
            int Max, Top, Apuntador;
            string[] Pila;

            //constructor de la clase
            public Pilas(int tamaño)
            {
                Max = tamaño;
                Top = -1;
                Pila = new string[tamaño];

                Console.WriteLine("\nLa pila ha sido creada con éxito.");
            }

            //métodos de la clase
            public void Push(string Elemento)
            {
                if (Top != Max - 1)
                {
                    Top = Top + 1;
                    Pila[Top] = Elemento;
                }
                else
                {
                    Console.WriteLine("\n-La Pila Esta Llena.");
                }
            }
            public void Pop()
            {
                if (Top != -1)
                {
                    Console.WriteLine("\nDato a Eliminar: " + Pila[Top]);
                    Pila[Top] = "";
                    Top = Top - 1;
                }
                else
                {
                    Console.WriteLine("\n-La Pila Esta vacia");
                }
            }
            public void Recorrido()
            {
                if (Top != -1)
                {
                    Apuntador = Top;

                    while (Apuntador != -1)
                    {
                        Console.WriteLine("\n-Elemento: " + Pila[Apuntador]);
                        Console.WriteLine("-Posicion: " + Apuntador);

                        Apuntador = Apuntador - 1;
                    }
                }
                else
                {
                    Console.WriteLine("\nLa Pila Esta Vacia");
                }
            }

            public void Busqueda(string Elemento)
            {
                if (Top != -1)
                {
                    Apuntador = Top;

                    while (Apuntador != -1)
                    {
                        if (Pila[Apuntador] == Elemento)
                        {
                            Console.WriteLine("\n-El elemento es: " + Elemento + "\n-Fue encontrador en la posicion: " + Apuntador);
                            return;
                        }
                        else
                        {
                            Apuntador = Apuntador - 1;
                        }
                    }
                    Console.WriteLine("\nEl Dato {0} No se Econtro en la pila", Elemento);
                }
                else
                {
                    Console.WriteLine("\nLa pila esta Vacia.");
                }
            }

            //destructor de la clase
            ~Pilas()
            {
                Console.WriteLine("\nMemoria Liberada Clase Pila");
            }
        }
        static void Main(string[] args)
        {
            char op = 'x';

            Pilas MyPila = null;

            Stopwatch SW = new Stopwatch();
            long TotalInicio = GC.GetTotalMemory(true);

            SW.Start();
            do
            {
                Console.Clear();
                Console.WriteLine("\t-PILA Nombres del mes-");
                Console.WriteLine("\na) Crear la Pila.");
                Console.WriteLine("b) Insertar un Elemento.");
                Console.WriteLine("c) Eliminar el Dato del Tope.");
                Console.WriteLine("d) Recorrer la Pila.");
                Console.WriteLine("e) Buscar un Elemento.");
                Console.WriteLine("f) Salir del Programa.");
                Console.Write("\nOpcion: ");

                try
                {
                    op = char.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 'a':

                            Console.Clear();
                            Console.Write("Ingrese Tamaño de la pila: ");
                            int numero = int.Parse(Console.ReadLine());

                            MyPila = new Pilas(numero);

                            break;

                        case 'b':

                                Console.Clear();

                                Console.Write("Inserte Nombre del mes: ");
                                string elemento = Console.ReadLine();

                                MyPila.Push(elemento);

                            break;

                        case 'c':

                            Console.Clear();

                            MyPila.Pop();

                            break;

                        case 'd':

                            Console.Clear();

                            MyPila.Recorrido();

                            break;

                        case 'e':

                            Console.Clear();

                            Console.Write("Mes a Buscar: ");
                            string Ebuscar = Console.ReadLine();

                            MyPila.Busqueda(Ebuscar);

                            break;

                        case 'f':
                            SW.Stop();

                            TimeSpan Ts = SW.Elapsed;
                            string ElapseTime = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", Ts.Hours, Ts.Minutes, Ts.Seconds, Ts.Milliseconds);

                            Console.WriteLine("\nTiempo De Ejecucion: {0} Milisegundos", ElapseTime);

                            long ToatalFinal = System.GC.GetTotalMemory(false);

                            Console.WriteLine("\nLa Cantidad de Memoria en Bytes es: {0}", ToatalFinal - TotalInicio);

                            break;

                        default:
                            Console.WriteLine("\nOpcion Invalida");
                            break;
                    }

                }
                catch (FormatException a)
                {
                    Console.WriteLine("\n{0}", a.Message);
                }
                finally
                {
                    Console.WriteLine("\nPresione <ENTER> Para Salir...");
                    Console.ReadKey();
                }

            } while (op != 'f');
        }
    }
}

