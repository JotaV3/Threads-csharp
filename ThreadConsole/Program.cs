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
            Thread secondaryThread = new Thread(new ThreadStart(SecondaryThread));
            secondaryThread.IsBackground = true;
            secondaryThread.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread Principal: " + i);
                Thread.Sleep(500);
            }
        }

        private static void SecondaryThread()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread Secundária: " + i);
                Thread.Sleep(1000);
            }
        }
    }
}
