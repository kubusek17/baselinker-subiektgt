using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SellIntegro.OrderProcessor.Helpers;
using SellIntegro.OrderProcessor.Models;

namespace SellIntegro.OrderProcessor
{
    class Receiver
    {
        string Token = "1001455-1007053-1Y9YLIFRAY10L3XIOINGDMYFNVTLFCUSZAAZOCFZ8GABF89IZDIT257JCWRI4JSA";
        string Url = "https://api.baselinker.com/connector.php";

        public async Task<List<Order>> ReceiveOrdersAsync()
        {
            var orders = new List<Order>();
            long dateTimeFrom = 0;
            Data downloadedData;
            do
            {
                downloadedData =await GetOrdersAsync(dateTimeFrom);
                orders.AddRange(downloadedData.Orders);
                dateTimeFrom = UnixDateTimeConverter.ConvertToUnixDate(orders.Last().DateConfirmed);
            }
            while (downloadedData.Status == "SUCCESS" && downloadedData.Orders.Count() == 100);
            return orders;
        }

        public async Task<Data> GetOrdersAsync(long dateTimeFrom=0)
        {
            using (var httpClient = new HttpClient())
            {

                var parameters = new Dictionary<string, string>
                {
                {"token",Token },
                {"method","getOrders" },
                {"parameters","{\"date_confirmed_from\":"+dateTimeFrom+",\"get_unconfirmed_orders\":false}" }
                };

                var content = new FormUrlEncodedContent(parameters);

                var httpResponse = await httpClient.PostAsync(Url, content);

                if (httpResponse.StatusCode != HttpStatusCode.OK)
                    return new Data {ErrorCode = httpResponse.StatusCode.ToString()};

                var result = httpResponse.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Data>(result,new Newtonsoft.Json.Converters.UnixDateTimeConverter());

            }

        }
    }
}
