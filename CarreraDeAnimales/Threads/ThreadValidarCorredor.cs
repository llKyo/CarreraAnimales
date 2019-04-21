using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarreraDeAnimales.Threads
{
    public class ThreadValidarCorredor
    {
        private Thread thread;
        private string nombre;

        public ThreadValidarCorredor(Thread t, string n)
        {
            this.thread = t;
            this.nombre = n;
        }

        public void validar()
        {
            while (thread.IsAlive)
            {

            } 
            Program.purga();
        }
    }
}
