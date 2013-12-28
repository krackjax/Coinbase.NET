﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Coinbase.Net.Types;
using Newtonsoft.Json.Linq;

namespace Coinbase.Net.Api
{
    public partial class CoinbaseClient
    {
        public async Task<PriceUnit> GetBalance()
        {
            var url = GetAccountBalanceUrl();
            var response = await this.GetAuthenticatedResource(url);
            return PriceUnit.FromJToken(response);
        }

        public async Task<AccountReceiveAddress> GetReceiveAddress()
        {
            var url = GetReceiveAddressUrl();
            var response = await GetAuthenticatedResource(url);

            var isSuccess = response["success"].Value<bool>();
            var address = response["address"].Value<string>();
            var callbackUrl = response["callback_url"].Value<string>();

            return new AccountReceiveAddress(isSuccess, address, callbackUrl);
        }

        public async Task<AccountNewReceiveAddress> GetNewReceiveAddress(string callbackUrl = null)
        {
            var url = GetNewReceiveAddressUrl();
            var kvp = new Dictionary<string, object>();

            if (!String.IsNullOrWhiteSpace(callbackUrl))
            {
                kvp.Add("address", new Dictionary<string, object> {
                            {"callback_url", callbackUrl} });
            }

            var response = await GetAuthenticatedResource(url,
                    HttpMethod.Post,
                    kvp
                );

            var isSuccess = response["success"].Value<bool>();
            var address = response["address"].Value<string>();
            var cbUrl = response["callback_url"].Value<string>();

            return new AccountNewReceiveAddress(isSuccess, address, cbUrl);
        }

        private string GetAccountBalanceUrl()
        {
            return BaseUrl + "account/balance";
        }

        private string GetReceiveAddressUrl()
        {
            return BaseUrl + "account/receive_address";
        }

        private string GetNewReceiveAddressUrl()
        {
            return BaseUrl + "account/generate_receive_address";
        }
    }
}
