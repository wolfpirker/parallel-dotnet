using System.ComponentModel.Design.Serialization;
using System.Security.Principal;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace IntroducingTasks
{
    class WaitingForTimeToPass
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new();
            CancellationToken token = cts.Token;
            var t = new Task(() =>
            {
                Console.WriteLine("I take 5 seconds");

                for (int i = 0; i < 5; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("I am done.");
            }, token);
            t.Start();

            Task t2 = Task.Factory.StartNew(() => Thread.Sleep(3000), token);

            //Task.WaitAll(t, t2);
            //Task.WaitAny(t, t2);
            Task.WaitAny(new[] { t, t2 }, 4000);

            Console.WriteLine($"Task t status is {t.Status}");
            Console.WriteLine($"Task t2 status is {t2.Status}");

            // Task.WaitAll(); // waits any number of tasks
            // t.Wait(); // just waits for this single task
            t.Wait(token); // overload with cancellation token
            // you can choose any of that

            Console.WriteLine("Main program done.");
            Console.ReadKey();
        }
    }
}