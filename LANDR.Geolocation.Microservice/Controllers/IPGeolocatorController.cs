using LANDR.Geolocation.Microservice.Behaviors;
using LANDR.Geolocation.Microservice.GeoIP.Manager;
using LANDR.Geolocation.Microservice.ModelHelpers;
using LANDR.Geolocation.Microservice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LANDR.Geolocation.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPGeolocatorController : ControllerBase
    {
        private readonly IQueryManager query;
        private readonly ConfigurationMicroservice configurationMicroservice;
        public IPGeolocatorController (IOptions<ConfigurationMicroservice> configration, SwitchOnlineLocal switchOL)
        {
            configurationMicroservice= configration.Value;
            query = switchOL(configurationMicroservice.OnlineService);
        }
        // GET: api/<IPGeolocatorController>
        [HttpGet]
        public async Task<IPData> GetAsync()
        {
            string clientIP = HttpContext.Connection.RemoteIpAddress?.ToString();
            return await query.GetIPData(clientIP);
        }

        // GET api/<IPGeolocatorController>/5
        [HttpGet("{IP}")]
        public async Task<IPData> GetAsync(string IP)
        {
            return await query.GetIPData(IP);
        }

        // POST api/<IPGeolocatorController>
        [HttpPost]
        public async Task<IEnumerable<IPData>> Post([FromBody] string[] IPs)
        {
            return await query.GetIPsData(IPs);
        }
    }
}
