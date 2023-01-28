using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1
{
    internal static class Program
    {
        public static void Write(char c){
            int i = 1000;
            while (i -- > 0){
                Console.Write(c);
            }
        }

        public static void Write(object o){
            int i = 1000;
            while (i -- > 0){
                // instead of char, we write the object
                Console.Write(o);
            }
        }

        public static void Main()
        {
            Task t = new Task(Write, "hello");
            t.Start();
            Task.Factory.StartNew(Write, 123);

            Console.WriteLine("Main programm done.");
            Console.ReadKey();
        }
    }
}