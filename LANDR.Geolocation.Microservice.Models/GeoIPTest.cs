namespace LANDR.Geolocation.Microservice.Models
{
    public class IPData
    {
        public string IP { get; set; }
        public ISPData ISPData { get; set; }
        public Continent GeoData { get; set; }
        public short CodeResponse { get; set; }
        public string Message { get; set; }
    }
    public class Country
    {
        public string IsoCode { get; set; }
        public string CountryName { get; set; }
        public City City { get; set; }
    }

    public class City
    {
        public string CityName { get; set; }
        public string SpecificCityName { get; set; }
        public Location Location { get; set; }
    }
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string TimeZone { get; set; }
    }
    public class ISPData
    {
        public string ISPOrganization { get; set; }
        public string ISP { get; set; }
        public string ISPDomain { get; set; }
    }
    public class Continent
    {
        public string ContinentName { get; set;}
        public Country Country { get; set; }
    }
}