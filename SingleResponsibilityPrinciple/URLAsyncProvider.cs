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

        IEnumerable<string> ITradeDataProvider.GetTradeData()
        {
            var tradeData =  Task.Run(() => _tradeDataProvider.GetTradeData());
            tradeData.Wait();
            return tradeData.Result;
        }
    }
}
