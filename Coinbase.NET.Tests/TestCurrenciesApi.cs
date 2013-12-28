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
            List<Currency>currencies = CoinbaseClient.GetCurrencies().Result;

            Assert.IsNotNull(currencies);
            Assert.IsTrue(currencies.Count > 0);
            Assert.AreEqual("AFN", currencies[0].Code);
        }
    }
}
