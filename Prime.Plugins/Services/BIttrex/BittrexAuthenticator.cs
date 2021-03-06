﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Prime.Common;

namespace Prime.Plugins.Services.Bittrex
{
    internal class BittrexAuthenticator : BaseAuthenticator
    {
        public BittrexAuthenticator(ApiKey apiKey) : base(apiKey)
        {
        }

        public override void RequestModify(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var headers = request.Headers;

            var nonce = GetLongNonce().ToString();

            var properties = new string[]
            {
                $"apiKey={ApiKey.Key}",
                $"nonce={nonce}"
            };

            var aggrInitialValue = String.IsNullOrEmpty(request.RequestUri.Query)
                ? "?"
                : request.RequestUri.Query + "&";

            var queryParams = properties.Aggregate(aggrInitialValue, (s, cur) => s += cur + "&").TrimEnd('&');
            request.RequestUri = new Uri(request.RequestUri, queryParams);

            var sign = HashHMACSHA512Hex(request.RequestUri.OriginalString, ApiKey.Secret);

            headers.Add("apisign", sign);
        }
    }
}
