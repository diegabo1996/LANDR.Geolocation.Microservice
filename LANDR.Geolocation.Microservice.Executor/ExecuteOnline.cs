using LANDR.Geolocation.Microservice.Executor.Helpers;
using LANDR.Geolocation.Microservice.Models;
using MaxMind.GeoIP2;

namespace LANDR.Geolocation.Microservice.Executor
{
    public class ExecuteOnline : IExecutor
    {
        private readonly WebServiceClient _maxMindClient;
        public ExecuteOnline(WebServiceClient maxMindClient)
        {
            _maxMindClient = maxMindClient;
        }
        public async Task<IPData> Execute(string IP)
        {
            try
            {
                var response = await _maxMindClient.CityAsync(IP);
                var Mapped = Mappers.City(response);
                Mapped.Message = "Ok";
                Mapped.CodeResponse = 200;
                return Mapped;
            }
            catch (Exception ex)
            {
                return new IPData { Message = ex.Message, CodeResponse = 500, IP = IP };
            }
        }
    }
}