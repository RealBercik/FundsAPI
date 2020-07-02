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

        public async Task<IList<FundDetails>> GetFunds(string id)
        {
            var funds = await _fundsData.LoadFundsData();

            // I have changed this from .Single for two reasons:
            // 1. If nothing is found an exception is thrown and I prefer handling things 'gracefully'.
            // 2. By selecting single we would return a class of FundDetails. This creates an inconsistency in method behaviour as not passing in the id returns a List<FundDetails>.
            return funds.Where(x => x.MarketCode == id).ToList();
        }

        public async Task<IList<FundDetails>> GetManagerFunds(string manager)
        {
            var funds = await _fundsData.LoadFundsData();

            return funds.Where(x => x.Name == manager).ToList();
        }
    }
}
