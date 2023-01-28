using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1
{
    internal static class Program
    {     

        public static void Main()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            token.Register(() => 
            {
                Console.WriteLine("Cancelation has been requested");
            });

            var t = new Task(() => {
                int i = 0;
                while (true){
                    token.ThrowIfCancellationRequested();
                    /* 
                    // this is the longer way of doing it...
                    if (token.IsCancellationRequested)
                    {
                        throw new OperationCanceledException();
                    }
                    */
                    Console.WriteLine($"{i++}\t");
                }
            
            }, token);

            t.Start();

            // another way of cancellation:
            Task.Factory.StartNew(() => {
                token.WaitHandle.WaitOne();
                Console.WriteLine("CancellationToken has been requested.");
            });

            Console.ReadKey();
            cts.Cancel();

            Console.WriteLine("Main program done.");
            Console.ReadKey();
        }
    }
}