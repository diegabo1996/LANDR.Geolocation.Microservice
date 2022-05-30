using LANDR.Geolocation.Microservice.GeoIP.Manager;
using LANDR.Geolocation.Microservice.ModelHelpers;
using LANDR.Geolocation.Microservice.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LANDR.Geolocation.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPGeolocatorOnlineController : ControllerBase
    {
        private readonly IQueryManager query;
        private readonly ILogger<WeatherForecastController> _logger;
        public IPGeolocatorOnlineController(QueryOnline onlineService, ILogger<WeatherForecastController> logger)
        {
            query = onlineService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IPData> GetAsync()
        {
            string clientIP = Request.Headers["x-forwarded-for"].ToString() ?? HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
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
