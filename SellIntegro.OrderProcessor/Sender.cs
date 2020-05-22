using System.Collections.Generic;
using System.Linq;
using InsERT;
using SellIntegro.OrderProcessor.Models;

namespace SellIntegro.OrderProcessor
{
    class Sender
    {
        readonly Subiekt Subiekt;

        public Sender()
        {
            var gt = new GT
            {
                Produkt = ProduktEnum.gtaProduktSubiekt,
                Serwer = "(local)\\INSERTGT",
                Baza = "test"
            };
            Subiekt = (Subiekt)gt.Uruchom((int)UruchomDopasujEnum.gtaUruchomDopasuj, (int)UruchomEnum.gtaUruchomWTle);
        }

        public void SendOrders(List<Order> orders)
        {
            foreach (var order in orders.Where(order => !OrderExists("\'" + order.Id + "\'")))
            {
                SendOrderToErp(order);
            }
        }

        private bool OrderExists(string id)
        {
            var criteria = "dok_NrPelnyOryg=" + id;
            return Subiekt.SuDokumentyManager.OtworzKolekcje(criteria, "").Liczba > 0;
        }
        private void SendOrderToErp(Order order)
        {
            var document = Subiekt.SuDokumentyManager.DodajZK();
            document.NumerOryginalny = order.Id;
            var customer = GetOrCreateCustomer(order.DeliveryFullName);

            document.KontrahentId = customer.Identyfikator;
            document.Zapisz();

            document.Zamknij();
        }

        private Kontrahent GetOrCreateCustomer(string symbol)
        {
            Kontrahent customer;

            if (symbol == "")
                symbol = "Brak";

            if (Subiekt.KontrahenciManager.IstniejeWg(symbol, KontrahentParamWyszukEnum.gtaKontrahentWgSymbolu))
            {
                customer = Subiekt.KontrahenciManager.WczytajKontrahentaWg(symbol,
                    KontrahentParamWyszukEnum.gtaKontrahentWgSymbolu);
            }
            else
            {
                customer = Subiekt.KontrahenciManager.DodajKontrahenta();
                customer.Symbol = "Brak";
                customer.Nazwa = "Brak";
                customer.Zapisz();
              
            }

            return customer;
        }
    }
}
