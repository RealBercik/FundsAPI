using Api.DataFiles;
using Api.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Api.DataLayer
{
    public class FundsData : IFundsData
    {
        private const string DataFilePath = "./DataFiles/funds.json";

        public async Task<IList<FundDetails>> LoadFundsData()
        {
            // We could handle this here by for example providing a default file or returning null et cetera.
            if (!File.Exists(DataFilePath)) return new List<FundDetails>();

            // Explicit path for System IO is no longer required (name of class File clashes with another when used in the API controller layer).
            var file = await File.ReadAllTextAsync(DataFilePath);

            // Check if anything to deserialize then return.
            return string.IsNullOrWhiteSpace(file) ? new List<FundDetails>() : JsonConvert.DeserializeObject<IList<FundDetails>>(file);
        }
    }
}
