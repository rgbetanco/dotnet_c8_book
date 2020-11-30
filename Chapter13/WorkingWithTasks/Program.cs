using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace WorkingWithTasks
{
    class Program
    {
        static void MethodA(){
            WriteLine("Starting Method A...");
            Thread.Sleep(3000);
            WriteLine("Finished Method A...");
        }

        static void MethodB(){
            WriteLine("Starting Method B...");
            Thread.Sleep(2000);
            WriteLine("Finished Method B...");
        }
        static void MethodC(){
            WriteLine("Starting Method C...");
            Thread.Sleep(1000);
            WriteLine("Finished Method C...");
        }
        //CallWebService is a class to simulate continuation tasks
        static decimal CallWebService(){
            WriteLine("Starting to call web service...");
            Thread.Sleep((new Random().Next(2000, 4000)));
            WriteLine("Finished call to web service");
            return 89.99M;
        }
        static string CallStoredProcedure(decimal amount){
            WriteLine("Starting to call stored procedure...");
            Thread.Sleep((new Random().Next(2000, 4000)));
            WriteLine("Finish calling stored procedure");
            return $"12 products cost more than {amount:C}.";
        }
        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();
            // WriteLine("Running methods synchronously on one thread");
            // MethodA();
            // MethodB();
            // MethodC();
            WriteLine("Running methods asynchronously on multiple threads");
/*
            // First method to create and start a thread
            Task taskA = new Task(MethodA);
            taskA.Start();
            // Second method to create and start a thread
            Task taskB = Task.Factory.StartNew(MethodB);
            // Third method to create and start a thread
            Task taskC = Task.Run(new Action(MethodC));
            // This is just an example of how to wait for a thread to complete
            Task[] tasks = { taskA, taskB, taskC };
            Task.WaitAll(tasks);
*/          
            WriteLine("Passing the result of one task as an input into another");
            var taskCallWebServiceAndThenStoredProcedure = Task.Factory.StartNew(CallWebService)
                .ContinueWith(previousTask => CallStoredProcedure(previousTask.Result));
            WriteLine($"Result:{taskCallWebServiceAndThenStoredProcedure.Result}");
            WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed");
        }
    }
}
