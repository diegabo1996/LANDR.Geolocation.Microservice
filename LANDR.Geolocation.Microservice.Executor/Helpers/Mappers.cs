using LANDR.Geolocation.Microservice.Models;
using MaxMind.GeoIP2.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LANDR.Geolocation.Microservice.Executor.Helpers
{
    public class Mappers
    {
        public static IPData City(CityResponse CityData)
        {
            IPData data = new IPData();
            data.IP = CityData.Traits.IPAddress;
            if (CityData != null)
            {
                data.GeoData = new Continent();
                if (CityData.Continent != null)
                {
                    data.GeoData.ContinentName = CityData.Continent.Name??"Unknow";
                }
                data.GeoData.Country = new Country();
                if (CityData.Country != null)
                {
                    data.GeoData.Country.CountryName = CityData.Country.Name??"Unknow";
                    data.GeoData.Country.IsoCode = CityData.Country.IsoCode;
                }
                data.GeoData.Country.City=new City();
                if (CityData.City != null)
                {
                    data.GeoData.Country.City.CityName=CityData.City.Name??"Unknow";
                }
                if (CityData.MostSpecificSubdivision != null)
                {
                    data.GeoData.Country.City.SpecificCityName = CityData.MostSpecificSubdivision.Name??"Unknow";
                }
                if (CityData.Location != null)
                {
                    data.GeoData.Country.City.Location=new Location();
                    if (CityData.Location.HasCoordinates)
                    {
                        data.GeoData.Country.City.Location.Longitude= (double)CityData.Location.Longitude;
                        data.GeoData.Country.City.Location.Latitude= (double)CityData.Location.Latitude;
                    }
                    data.GeoData.Country.City.Location.TimeZone= CityData.Location.TimeZone??"Unknow";
                }
                if (CityData.Traits != null)
                {
                    data.ISPData= new ISPData();
                    data.ISPData.ISPDomain = CityData.Traits.Domain ?? "Unknow";
                    data.ISPData.ISP = CityData.Traits.Isp ?? "Unknow";
                    data.ISPData.ISPOrganization = CityData.Traits.Organization ?? "Unknow";
                }
            }
            else
            {
                throw new Exception("City object is null");
            }
            return data;
        }
    }
}
