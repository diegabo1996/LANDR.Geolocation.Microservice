using LANDR.Geolocation.Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LANDR.Geolocation.Microservice.GeoIP.Manager
{
    public interface IQueryManager
    {
        Task<IEnumerable<IPData>> GetIPsData(string[] IPs);
        Task<IPData> GetIPData(string IP);
    }
}
