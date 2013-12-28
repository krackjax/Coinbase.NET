using Coinbase.Net.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinbase.Net.Api
{
    public partial class CoinbaseClient
    {
        public async static Task<List<Currency>> GetCurrencies()
        {
            var url = GetCurrenciesUrl();
            var currenciesObject = await GetUnauthenticatedJArrayResource(url);

            List<Currency> currencies = new List<Currency>();
            foreach (JToken jToken in currenciesObject)
            {
                currencies.Add(Currency.FromJToken(jToken));
            }

            return currencies;
        }

        private static string GetCurrenciesUrl()
        {
 	        return BaseUrl + "currencies";
        }
    }
}
