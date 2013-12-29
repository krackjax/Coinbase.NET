using Coinbase.Net.Api;
using Coinbase.Net.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinbase.Net.Tests
{
    [TestClass]
    public class TestCurrenciesApi
    {
        [TestMethod]
        public void TestGetCurrencies()
        {
            string[,] currencies = CoinbaseClient.GetCurrencies().Result;

            Assert.IsNotNull(currencies);
            Assert.AreEqual("AFN", currencies[0,1]);
        }

        [TestMethod]
        public void TestGetExchangeRates()
        {
            Dictionary<string, double> exchangeRates = CoinbaseClient.GetExchangeRates().Result;

            Assert.IsNotNull(exchangeRates);
            Assert.IsTrue(exchangeRates["btc_to_usd"] > 0);
        }
    }
}
