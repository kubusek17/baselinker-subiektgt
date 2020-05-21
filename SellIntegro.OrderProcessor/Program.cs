using InsERT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SellIntegro.OrderProcessor
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            OrderProcessor orderProcessor = new OrderProcessor();
            orderProcessor.ProcessOrders();
        }
    }
}
