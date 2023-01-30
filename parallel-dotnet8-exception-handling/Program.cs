
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
            var t = Task.Factory.StartNew(() =>
            {
                throw new InvalidOperationException();
            });

            var t2 = Task.Factory.StartNew(() =>
            {
                throw new AccessViolationException("Can't access this!") { Source = "t2" };
            });

            try
            {
                Task.WaitAll(t, t2);
            }
            catch (AggregateException ae)
            {
                Console.WriteLine("Some exceptions we didn't expect:");
                foreach (var e in ae.InnerExceptions)
                    Console.WriteLine($" - {e.GetType()} from {e.Source}");
            }


            Console.WriteLine("Main program done.");
            Console.ReadKey();
        }
    }
}