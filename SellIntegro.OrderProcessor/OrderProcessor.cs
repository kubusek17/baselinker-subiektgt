using InsERT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellIntegro.OrderProcessor
{
    class OrderProcessor
    {
        public void ProcessOrders()
        {
            var receiver = new Receiver();
            var sender = new Sender();
            var orders = receiver.GetOrdersAsync();
            sender.SendOrders(orders.Result);

        }
    }
}

