﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.Plugins.Services.HitBtc
{
    internal class HitBtcSchema
    {
        internal class SymbolsResponse
        {
            public SymbolResponse[] symbols;
        }

        internal class TickersResponse : Dictionary<string, TickerResponse> { }

        internal class TickerResponse
        {
            public decimal? ask;
            public decimal? bid;
            public decimal? last;
            public decimal? low;
            public decimal? high;
            public decimal volume;
            public decimal volume_quote;
            public long timestamp;
        }

        internal class BalancesResponse
        {
            public BalanceResponse[] balance;
        }

        internal class BalanceResponse
        {
            public string currency_code;
            public decimal balance;
        }

        internal class DepositAddressResponse
        {
            public string address;
        }

        internal class SymbolResponse
        {
            public string symbol;
            public decimal step;
            public decimal lot;
            public string currency;
            public string commodity;
            public decimal takeLiquidityRate;
            public decimal provideLiquidityRate;
        }
    }
}
