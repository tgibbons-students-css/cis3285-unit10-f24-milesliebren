using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class RestfulTradeDataProvider : ITradeDataProvider
    {
        private readonly string url;
        private readonly ILogger logger;
        private readonly HttpClient client = new HttpClient();

        public RestfulTradeDataProvider(string url, ILogger logger)
        {
            this.url = url;
            this.logger = logger;
        }

        private async Task<List<string>> GetTradeAsync()
        {
            logger.LogInfo("Connecting to the Restful server using HTTP");

            List<string> tradesString = new List<string>();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                // Read the content as a string and deserialize it into a List<string>
                string content = await response.Content.ReadAsStringAsync();
                tradesString = JsonSerializer.Deserialize<List<string>>(content);
                logger.LogInfo("Received trade strings of length = " + tradesString.Count);
            }

            return tradesString;
        }

        public async Task<IEnumerable<string>> GetTradeData()
        {
            // Directly await GetTradeAsync, avoiding Task.Run
            var trades = await GetTradeAsync();
            return trades;
        }
    }
}
