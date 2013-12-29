using Coinbase.Net.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace Coinbase.Net.Api
{
    public partial class CoinbaseClient
    {
        public async static Task<string[,]> GetCurrencies()
        {
            var url = CoinbaseClient.GetCurrenciesUrl();
            var currencies = await CoinbaseClient.GetUnauthenticatedJResourceAsString(url);

            return JsonConvert.DeserializeObject<string[,]>(currencies);
        }

        public async static Task<Dictionary<string, double>> GetExchangeRates()
        {
            var url = GetExchangeRatesUrl();
            var exchangeRates = await GetUnauthenticatedJResourceAsString(url);
            
            return JsonConvert.DeserializeObject<Dictionary<string, double>>(exchangeRates);
        }

        private static string GetCurrenciesUrl()
        {
 	        return BaseUrl + "currencies";
        }

        private static string GetExchangeRatesUrl()
        {
            return BaseUrl + "currencies/exchange_rates";
        }
    }
}