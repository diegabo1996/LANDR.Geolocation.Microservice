using LANDR.Geolocation.Microservice.GeoIP;
using LANDR.Geolocation.Microservice.GeoIP.Manager;
using MaxMind.GeoIP2;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace LANDR.Geolocation.Microservice.Tests
{
    public class ConnectionTest
    {
        private WebServiceClient webServiceClient;
        private DatabaseReader databaseReader;
        private IQueryManager queryManager;
        [SetUp]
        public async Task SetupAsync()
        {
            webServiceClient = new WebServiceClient(723864, "gmOzUxIZsddwrWuM");
            databaseReader = new DatabaseReader(AppDomain.CurrentDomain.BaseDirectory + @"LocalDataBase/City.mmdb");
        }

        [Test]
        public async Task OnlineConnection()
        {
            try
            {
                queryManager = new QueryOnline(webServiceClient);
                var testData = await queryManager.GetIPData("200.105.212.44");
                Assert.IsNotNull(testData);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
        [Test]
        public async Task LocalConnection()
        {
            try
            {
                queryManager = new QueryLocal(databaseReader);
                var testData = await queryManager.GetIPData("200.105.212.44");
                Assert.IsNotNull(testData);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}