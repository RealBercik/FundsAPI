using Api.DataFiles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IFundsData
    {
        Task<IList<FundDetails>> LoadFundsData();
    }
}
