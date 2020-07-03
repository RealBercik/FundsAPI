using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class FundOutput
    {
        private decimal _currentUnitPrice;
        public bool Active { get; set; }

        public decimal CurrentUnitPrice
        {
            get => _currentUnitPrice;
            set => _currentUnitPrice = decimal.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        public string FundManager { get; set; }

        public string Name { get; set; }

        public string MarketCode { get; set; }
    }
}
