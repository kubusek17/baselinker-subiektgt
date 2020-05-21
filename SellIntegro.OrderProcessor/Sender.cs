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
       
        private bool Exists(int orderId)
        {
            return false;
        }
        private void SenddOrderToERP(Order order)
        {
            InsERT.GT gt = new InsERT.GT();
            gt.Produkt = InsERT.ProduktEnum.gtaProduktSubiekt;
            gt.Serwer = "(local)\\INSERTGT";
            gt.Baza = "test";
            gt.Operator = "Kowalski Jan";
            gt.OperatorHaslo = "";
            gt.Uzytkownik = "Szef";
            gt.UzytkownikHaslo = "";
        }
    }
}
