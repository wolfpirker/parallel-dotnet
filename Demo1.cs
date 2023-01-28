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


        public static void Main()
        {
            Task.Factory.StartNew(() => Write('.'));

            var t = new Task(() => Write('?'));
            T.Start();

            Write('-');

            Console.WriteLine("Main programm done.");
            Console.ReadKey();
        }
    }
}