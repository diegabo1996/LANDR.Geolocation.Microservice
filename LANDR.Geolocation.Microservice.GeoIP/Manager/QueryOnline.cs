using LANDR.Geolocation.Microservice.Executor;
using LANDR.Geolocation.Microservice.Models;
using MaxMind.GeoIP2;

namespace LANDR.Geolocation.Microservice.GeoIP.Manager
{
    public class QueryOnline: IQueryManager
    {
        private readonly IExecutor Executor;
        public QueryOnline(WebServiceClient webServiceClient)
        {
            Executor = new ExecuteOnline(webServiceClient);
        }
        public async Task<IPData> GetIPData(string IP)
        {
            return await Executor.Execute(IP);
        }

        public async Task<IEnumerable<IPData>> GetIPsData(string[] IPs)
        {
            List<IPData> iPsData = new List<IPData>();
            foreach (string IP in IPs)
            {
                var data=await Executor.Execute(IP);
                iPsData.Add(data);
            }
            return iPsData;
        }
    }
}