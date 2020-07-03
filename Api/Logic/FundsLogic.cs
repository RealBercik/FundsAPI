using Api.DataFiles;
using Api.DataLayer;
using Api.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Logic
{
    public class FundsLogic
    {
        private readonly IFundsData _fundsData;

        public FundsLogic()
        {
            _fundsData = new FundsData();
        }

        // Eliding async/await as not needed here. This provides a small efficiency benefit as the compiler can skip generating the async state machine.
        public Task<IList<FundDetails>> GetFunds()
        {
            return _fundsData.LoadFundsData();
        }

        public async Task<FundDetails> GetFund(string id)
        {
            var funds = await _fundsData.LoadFundsData();

            // I have changed this from .Single to SingleOrDefault so we can return null, and therefore 204 NoContent instead of 500 when nothing is found.
            return funds.Where(x => x.MarketCode == id).SingleOrDefault();
        }

        public async Task<IList<FundDetails>> GetManagerFunds(string manager)
        {
            var funds = await _fundsData.LoadFundsData();

            return funds.Where(x => x.Name == manager).ToList();
        }
    }
}
