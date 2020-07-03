using System;
using Newtonsoft.Json;

namespace Api.DataFiles
{
    public class FundDetails
    {
        private decimal _currentUnitPrice;
        public bool Active { get; set; }

        public decimal CurrentUnitPrice
        {
            get => _currentUnitPrice;
            // When setting round to two decimal places using banker rounding MidpointRounding.AwayFromZero.
            set => _currentUnitPrice = decimal.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        public string FundManager { get; set; }

        public string Name { get; set; }

        [JsonProperty("MarketCode")]
        public string Code { get; set; }
    }
}