using LANDR.Geolocation.Microservice.Executor;
using LANDR.Geolocation.Microservice.Models;
using MaxMind.GeoIP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LANDR.Geolocation.Microservice.GeoIP.Manager
{
    public class QueryLocal : IQueryManager
    {
        private readonly IExecutor Executor;
        public QueryLocal(DatabaseReader databaseReader)
        {
            Executor = new ExecuteLocal(databaseReader);
        }
        public async Task<IPData> GetIPData(string IP)
        {
            return await Executor.Execute(IP);
        }

        public async Task<IEnumerable<IPData>> GetIPsData(string[] IPs)
        {
            IEnumerable<IPData> iPsData = new List<IPData>();
            foreach (string IP in IPs)
            {
                var data = await Executor.Execute(IP);
                iPsData.Append(data);
            }
            return iPsData;
        }
    }
}
