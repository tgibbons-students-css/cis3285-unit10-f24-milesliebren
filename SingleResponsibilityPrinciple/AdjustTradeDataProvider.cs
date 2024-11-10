using SingleResponsibilityPrinciple.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    internal class AdjustTradeDataProvider : ITradeDataProvider
    {
        private readonly ITradeDataProvider _tradeDataProvider;

        public AdjustTradeDataProvider(ITradeDataProvider tradeDataProvider)
        {
            _tradeDataProvider = tradeDataProvider;
        }

        public async Task<IEnumerable<string>> GetTradeData()
        {
            // Get the raw trade data from the underlying data provider asynchronously
            var tradeData = await _tradeDataProvider.GetTradeData();

            // Convert each instance of "GBP" to "EUR"
            var adjustedTradeData = tradeData.Select(trade => trade.Replace("GBP", "EUR"));

            return adjustedTradeData;
        }
    }
}
