using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    internal class URLAsyncProvider : ITradeDataProvider
    {
        private readonly ITradeDataProvider _tradeDataProvider;

        public URLAsyncProvider(ITradeDataProvider tradeDataProvider)
        {
            _tradeDataProvider = tradeDataProvider;
        }

        public async Task<IEnumerable<string>> GetTradeData()
        {
            // Call the base provider's GetTradeData asynchronously
            return await _tradeDataProvider.GetTradeData();
        }
    }
}
