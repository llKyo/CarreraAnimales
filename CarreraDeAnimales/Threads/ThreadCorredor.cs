using CarreraDeAnimales.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarreraDeAnimales.Threads
{
    public class ThreadCorredor
    {
        private int distancia;
        private int maxSalto;
        private string nombre;
        private static object obj = new object();
        private static string desplazamiento;
        private static int recorrido;

        public ThreadCorredor(int d, uint s, string n)
        {
            this.distancia = d;
            this.maxSalto = Convert.ToInt32(s);
            this.nombre = n;
        }
        int barraDesplacamiento(int recorrido, int avance)
        {
            /*  Regla de 3
             *  distancia   100%
             *  recorrido   x
             *  
             *  x -> perConDecimales
             * */
            float perConDecimales = recorrido * 100 / distancia;
            int perActual = Convert.ToInt32(Math.Ceiling(perConDecimales));
            desplazamiento = "";
            if (distancia < recorrido) 
            {
                perActual = 100;
            }
            for (int i = 0; i < perActual/2; i++)
            {
                desplazamiento += "█";
            }

            
            return perActual;

        }
        public void iniciarCarrera()
        {
            int recorrido = 0;
            int avance;
            desplazamiento = "";
            Random rd = new Random();
            int perActual;

            
            
            while (distancia >= recorrido)
            {

                Thread.Sleep(1000);
                avance = rd.Next(maxSalto);
                recorrido += avance;

                perActual = barraDesplacamiento(recorrido, avance);
                lock (obj)
                {
                    switch (Thread.CurrentThread.Name)
                    {
                        case "1":
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case "2":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case "3":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case "4":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case "5":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case "6":
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        default :
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }

                    Console.WriteLine("{0,-10} : {1,-50} {2,3}% : {3}",nombre, desplazamiento, perActual, recorrido);
                }
            }

            Console.WriteLine("{0} ganó la carrera", nombre);
        }
    }
}
