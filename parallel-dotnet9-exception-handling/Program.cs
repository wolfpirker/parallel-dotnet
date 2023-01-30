﻿using System.ComponentModel.Design.Serialization;
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
            try
            {
                Test();
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    Console.WriteLine($"Handled elsewhere: {e.GetType()}");
                }
            }


            Console.WriteLine("Main program done.");
            Console.ReadKey();
        }

        private static void Test()
        {
            var t = Task.Factory.StartNew(() =>
            {
                throw new InvalidOperationException("Can't do this!");
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
                ae.Handle(e =>
                {
                    if (e is InvalidOperationException)
                    {
                        Console.WriteLine("Invalid op!");
                        return true;
                    }
                    else return false;
                });
            }


        }
    }
}