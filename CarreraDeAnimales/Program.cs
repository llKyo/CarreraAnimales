using CarreraDeAnimales.Threads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarreraDeAnimales
{
    class Program
    {
        static List<Thread> threads = new List<Thread>();
        
        static Thread t;
        static int largo;


        static void carrera()
        {
            int nro = 0;
            ThreadCorredor tc = new ThreadCorredor(largo, 5,"Liebre");
            Thread ts = new Thread(new ThreadStart(tc.iniciarCarrera));
            nro += 1;
            ts.Name = nro.ToString();
            ts.Start();
            threads.Add(ts);
            ThreadValidarCorredor tv = new ThreadValidarCorredor(ts, "Liebre");
            Thread tValidado = new Thread(new ThreadStart(tv.validar));
            tValidado.Start();

            tc = new ThreadCorredor(largo, 10,"Tortuga");
            ts = new Thread(new ThreadStart(tc.iniciarCarrera));
            nro += 1;
            ts.Name = nro.ToString();
            ts.Start();
            threads.Add(ts);
            tv = new ThreadValidarCorredor(ts, "Tortuga");
            tValidado = new Thread(new ThreadStart(tv.validar));
            tValidado.Start();

            do
            {
                try
                {
                    Console.Write("Ingrese Animal: ");
                    string nombre = Console.ReadLine().Trim();
                    Console.Write("Ingrese Poder de salto : ");
                    uint salto = Convert.ToUInt32(Console.ReadLine().Trim());
                    tc = new ThreadCorredor(largo, salto, nombre);
                    ts = new Thread(new ThreadStart(tc.iniciarCarrera));
                    ts.IsBackground = false;
                    nro += 1;
                    ts.Name = nro.ToString();
                    threads.Add(ts);
                    ts.Start();

                    tv = new ThreadValidarCorredor(ts, nombre);
                    tValidado = new Thread(new ThreadStart(tv.validar));
                    tValidado.Start();
                }
                catch (Exception)
                {

                }
            } while (true);

            

        }
        public static void purga()
        {
            for (int i = 0; i < threads.Count; i++)
            {
                try
                {
                    threads[i].Abort();
                } catch (Exception ex)
                {

                }
            }
            t.Abort();
            
        }
        
        static void Main(string[] args)
        {
            bool continuar = false;
            bool validarLargo = false;
            string msj;
            do
            {
                try
                {
                    
                    Console.Write("Ingrese largo de la pista de carrera: \n> ");
                    largo = Convert.ToInt32(Console.ReadLine().Trim());
                    if (largo <= 0)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.Write("[Error] Debe ingresar un número mayor a 0");
                }
                t = new Thread(new ThreadStart(carrera));
                t.IsBackground = false;
                t.Start();
                while (t.IsAlive)
                {
                    Thread.Sleep(1000);
                }
                Console.Write("\n(Desea volver a jugar? (SI/NO)\n> ");
                msj = Console.ReadLine().Trim();
                if(msj.ToLower() == "si")
                {
                    continuar = true;
                    Console.Clear();
                } else
                {
                    continuar = false;
                }
            } while (continuar);
            Console.WriteLine("");
            Console.WriteLine(@"______                       ");
            Console.WriteLine(@"| ___ \             _        ");
            Console.WriteLine(@"| |_/ /_   _  ___  (_)   ___ ");
            Console.WriteLine(@"| ___ \ | | |/ _ \      / __|");
            Console.WriteLine(@"| |_/ / |_| |  __/  _  | (__ ");
            Console.WriteLine(@"\____/ \__, |\___| (_)  \___|");
            Console.WriteLine(@"        __/ |                ");
            Console.WriteLine(@"       |___/                 ");

            Console.Write("\n\nPresiona cualquier tecla para cerrar. . . ");      
            Console.ReadKey();
        }
        
    }
}
