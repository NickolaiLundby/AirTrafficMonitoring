using ATM.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ITransponderReceiver transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            new Factory(transponderReceiver);

            Console.ReadKey();
        }
    }
}
