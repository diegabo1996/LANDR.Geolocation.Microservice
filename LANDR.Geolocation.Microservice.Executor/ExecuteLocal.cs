using LANDR.Geolocation.Microservice.Executor.Helpers;
using LANDR.Geolocation.Microservice.Models;
using MaxMind.GeoIP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LANDR.Geolocation.Microservice.Executor
{
    public class ExecuteLocal : IExecutor
    {
        public readonly DatabaseReader databaseReader;
        public ExecuteLocal (DatabaseReader databaseReader)
        {
            this.databaseReader = databaseReader;
        }
        public async Task<IPData> Execute(string IP)
        {
            try
            { 
                var city = databaseReader.City(IP);
                var Mapped = Mappers.City(city);
                Mapped.Message = "Ok";
                Mapped.CodeResponse = 200;
                return Mapped;
            }
            catch (Exception ex)
            {
                return new IPData { Message = ex.Message, CodeResponse=500, IP=IP };
            }
        }
    }
}
