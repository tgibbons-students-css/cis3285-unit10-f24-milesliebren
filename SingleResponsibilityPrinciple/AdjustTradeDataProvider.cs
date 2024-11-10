using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    internal class AdjustTradeDataProvider : ITradeDataProvider
    {
        private URLTradeDataProvider _tradeDataProvider;

        public AdjustTradeDataProvider(URLTradeDataProvider uRLTradeDataProvider)
        {
            _tradeDataProvider = uRLTradeDataProvider;
        }

        public IEnumerable<string> GetTradeData()
        {
            // Get the raw trade data from the underlying data provider
            var tradeData = _tradeDataProvider.GetTradeData();

            // Convert each instance of "GBP" to "EUR"
            var adjustedTradeData = tradeData.Select(trade => trade.Replace("GBP", "EUR"));

            return adjustedTradeData;
        }
    }
}
