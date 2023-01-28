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

        public static int TextLength(object o){
            Console.WriteLine($"\n Task with id {Task.CurrentId} processing object {o}...");
            return o.ToString().Length;
        }

        public static void Main()
        {
            string text1 = "testing", text2 = "this";
            var task1 = new Task<int>(TextLength, text1);
            // we are calling that function on a separate thread
            // take text1 measure its length and return it to us
            // and also does the Writeline thing
            task1.Start();
            Task<int> task2 = Task.Factory.StartNew(TextLength, text2);

            Console.WriteLine($"Length of '{text1}' is {task1.Result}");
            Console.WriteLine($"Length of '{text2}' is {task2.Result}");


            Console.WriteLine("Main programm done.");
            Console.ReadKey();
        }
    }
}