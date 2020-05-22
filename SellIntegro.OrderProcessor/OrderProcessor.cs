namespace SellIntegro.OrderProcessor
{
    class OrderProcessor
    {
      

        public void ProcessOrders()
        {
            var receiver = new Receiver();
            var sender = new Sender();
            var orders=receiver.ReceiveOrdersAsync();
            sender.SendOrders(orders.Result);
        }
    }
}

