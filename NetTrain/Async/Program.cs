using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            //asyncTrain();
            //asyncCancelTrain();
            //asyncReturn();

            var t = Task.Run(() =>
               {
                   return GetNumber().GetAwaiter().GetResult();
               });
            t.Wait();
            Console.WriteLine(t.Result);

            Task.WaitAll(GetNumber());
            
            Console.ReadKey();
        }

        static async void MainAsync(string[] args)
        {
            await GetNumber();
        }

        public static void asyncTrain()
        {
            Console.WriteLine("This is task 1 , thread is :" + Thread.CurrentThread.ManagedThreadId);
            string str1 = string.Empty, str2 = string.Empty, str3 = string.Empty;
            var task1 = Task.Run(() =>
            {
                Thread.Sleep(500);
                str1 = "Zhang san";
                Console.WriteLine("This is task 2 , thread is :" + Thread.CurrentThread.ManagedThreadId);
            }).ContinueWith(temp =>
            {
                Thread.Sleep(500);
                str2 = "Li si";
                Console.WriteLine("This is task 3 , thread is :" + Thread.CurrentThread.ManagedThreadId);
            }).ContinueWith(t =>
            {
                Thread.Sleep(500);
                str3 = "Wang wu";
                Console.WriteLine("This is task 4 , thread is :" + Thread.CurrentThread.ManagedThreadId);
            });

            var task2 = Task.Run(() =>
             {
                 Thread.Sleep(500);
                 str1 = "Zhang san";
                 Console.WriteLine("This is task 5,task 2 , thread is :" + Thread.CurrentThread.ManagedThreadId);
             });

            task1.Wait();
            Console.WriteLine(str1 + str2 + str3);

            //task2.Wait();

            Task task = new Task(() =>
            {
                Console.WriteLine("This is new task run.");
            });
            task.Start();
            //task.Wait();


            Task taskFac = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("This is task factory.");
            });
            //taskFac.Wait();

            Task.WaitAll(task, task2, taskFac);

            Console.ReadKey();
        }

        public static void asyncCancelTrain()
        {

            var cts = new CancellationTokenSource();
            var ct = cts.Token;

            Task taskCancel = Task.Run(() =>
            {
                Console.WriteLine("This is a cancel task.");
            }, ct);

            try
            {
                cts.Cancel();
                taskCancel.Wait();
            }
            catch (AggregateException e)
            {
                foreach (var ex in e.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Is this task cancel? " + taskCancel.IsCanceled);
            }
        }

        public static void asyncReturn()
        {
            var task = Task.Run(() =>
            {
                return "Zhang San.";
            });

            Console.WriteLine("This is a return task: " + task.Result);
        }

        public static async Task<int> GetNumber()
        {
            var t = GetNum();
            t.Start();
            var t1 = await t;
            var tt = GetNum();
            tt.Start();
            var ta = await tt;
            return t1 + ta;
        }

        public static Task<int> GetNum()
        {
            return new Task<int>(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine("This is get num function.");
                return new Random().Next(100);
            });
        }
    }
}
