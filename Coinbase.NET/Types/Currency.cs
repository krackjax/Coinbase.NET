using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinbase.Net.Types
{
    public class Currency
    {
        public string Name { get; private set; }
        public string Code { get; private set; }

        public Currency(string name, string code)
        {
            this.Name = name;
            this.Code = code;
        }

        public static Currency FromJToken(JToken jToken)
        {
            string[] currency = jToken.Values<string>().ToArray<string>();
            
            return new Currency(currency[0], currency[1]);
        }
    }
}
