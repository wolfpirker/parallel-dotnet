using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroducingTasks
{
  class CancelingTasks
  {
    static void Main(string[] args)
    {
      CompositeCancelationToken();

      Console.WriteLine("Main program done, press any key.");
      Console.ReadKey();
    }    

    private static void CompositeCancelationToken()
    {
      // it's possible to create a 'composite' cancelation source that involves several tokens
      var planned = new CancellationTokenSource();
      var preventative = new CancellationTokenSource();
      var emergency = new CancellationTokenSource();

      // make a token source that is linked on their tokens
      var paranoid = CancellationTokenSource.CreateLinkedTokenSource(
        planned.Token, preventative.Token, emergency.Token);

      Task.Factory.StartNew(() =>
      {
        int i = 0;
        while (true)
        {
          paranoid.Token.ThrowIfCancellationRequested();
          Console.Write($"{i++}\t");
          Thread.Sleep(100);
        }
      }, paranoid.Token);

      paranoid.Token.Register(() => Console.WriteLine("Cancelation requested"));

      Console.ReadKey();

      // use any of the aforementioned token soures
      emergency.Cancel();
    }
}
}
