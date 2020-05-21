using InsERT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellIntegro.OrderProcessor
{
    class Sender
    {
        InsERT.Subiekt Subiekt;
        InsERT.GT Gt;
        public Sender()
        {
            Gt = new InsERT.GT();
            Gt.Produkt = InsERT.ProduktEnum.gtaProduktSubiekt;
            Gt.Serwer = "(local)\\INSERTGT";
            Gt.Baza = "test";
            Gt.Operator = "Kowalski Jan";
            Gt.OperatorHaslo = "";
            Gt.Uzytkownik = "Szef";
            Gt.UzytkownikHaslo = "";
            Subiekt = (InsERT.Subiekt)Gt.Uruchom((int)UruchomDopasujEnum.gtaUruchomDopasuj, (int)UruchomEnum.gtaUruchomWTle);
        }
       
        public void SendOrders(List<Order> orders)
        {
            if (!OrderExists("\'1231331232121\'"))
                SendOrderToErp(new Order());
            foreach(Order order in orders)
            {
                if(!OrderExists("\'2\'"))
                {
                    SendOrderToErp(order);
                }
            }
        }

        private bool OrderExists(string id)
        {
            string criteria = "dok_NrPelnyOryg=" + id;
            return Subiekt.SuDokumentyManager.OtworzKolekcje(criteria, "").Liczba>0;
        }
        public void SendOrderToErp(Order order)
        {
            if(!OrderExists("\'2\'"))
            {
               var document=Subiekt.SuDokumentyManager.DodajZK();
                document.NumerOryginalny = "1231331232121";
                Subiekt.KontrahenciManager.DodajKontrahentaJednorazowego();
                document.Pozycje.
                document.KontrahentId = 1;
                document.Zapisz();
                document.Zamknij();
            }
         
            

        }
    }
}
