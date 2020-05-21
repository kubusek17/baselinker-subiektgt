using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SellIntegro.OrderProcessor
{
    class Receiver
    {
        string Token = "1001455-1007053-1Y9YLIFRAY10L3XIOINGDMYFNVTLFCUSZAAZOCFZ8GABF89IZDIT257JCWRI4JSA";
        string Url = "https://api.baselinker.com/connector.php";
        public async Task<List<Order>> GetOrdersAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var parameters = new Dictionary<string, string>
                {
                {"token",Token },
                {"method","getOrders" }
                };

                var content = new FormUrlEncodedContent(parameters);

                var httpResponse = await httpClient.PostAsync(Url, content);
                await httpResponse.Content.ReadAsStringAsync();

                return new List<Order>();
            }
        }
    }
}
