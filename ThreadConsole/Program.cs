using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread threadSecundaria = new Thread(new ThreadStart(ThreadSecundaria));
            threadSecundaria.IsBackground = true;
            threadSecundaria.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread Principal: " + i);
                Thread.Sleep(500);
            }
        }

        private static void ThreadSecundaria()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread Secundária: " + i);
                Thread.Sleep(1000);
            }
        }
    }
}
