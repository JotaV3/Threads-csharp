using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task Part 1
            //Task task = new Task(ExampleTask);
            //task.Start();

            //Task taskRun = Task.Run(ExampleTask);

            //Task.Factory.StartNew(ExampleTask);

            //Task.Run(() => ForLooped("Task anônima"));

            //ForLooped("Task principal");
            #endregion

            #region Task Part 2
            //Task[] task = 
            //{ 
            //    Task.Run(() => ForLooped("Task anônima 1", 1)),
            //    Task.Run(() => ForLooped("Task anônima 2", 1)),
            //    Task.Run(() => ForLooped("Task anônima 3", 1))
            //};

            //Task.WaitAll(task);

            //Task task1 = Task.Run(() => ForLooped("Task anônima 1", 1));
            //Task task2 = Task.Run(() => ForLooped("Task anônima 2", 1));
            //Task task3 = Task.Run(() => ForLooped("Task anônima 3", 1));

            //Task.WaitAll(task1, task2, task3);

            //Console.WriteLine("Todas as tasks foram finalizadas");
            #endregion

            #region Task Part 3
            //Task<int> task1 = Task.Run(() => 5 * 2);

            Task<int> task2 = Task.Run(() =>
            {
                return new Random().Next(10);
            });

            Task<int> task3 = task2.ContinueWith((t) =>
            {
                return t.Result * 2;
            });

            Task<string> task4 = task3.ContinueWith((t) =>
            {
                return "Resultado final: " + t.Result;
            });

            Console.WriteLine(task4.Result);

            #endregion

            Console.ReadLine();
        }

        private static void ExampleTask()
        {
            ForLooped("Task secundária", 1);
        }

        private static int ExampleTaskWithResult(int num)
        {
            return num * 2;
        }

        private static void ForLooped(string message, int count)
        {
            for(int i = 0; i < count; i ++)
            {
                Console.WriteLine(message);
            }
        }
    }
}
