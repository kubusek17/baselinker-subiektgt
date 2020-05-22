using System;

namespace SellIntegro.OrderProcessor
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            var orderProcessor = new OrderProcessor();
            orderProcessor.ProcessOrders();
            Console.ReadLine();
        }
    }
}
