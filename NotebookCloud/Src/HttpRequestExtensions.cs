using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using MaxMind.Db;
using MaxMind.GeoIP2;

namespace NotebookCloud.Src
{
    public static class HttpRequestExtensions
    {
        private static readonly DatabaseReader Reader = new DatabaseReader(System.AppDomain.CurrentDomain.BaseDirectory + "bin\\GeoLite2-Country.mmdb", FileAccessMode.Memory);


        public static bool IsFromEU(this HttpRequestBase request)
        {
            try
            {   
                switch (request.GetCountry())
                {
                    case "Austria":
                    case "Belgium":
                    case "Bulgaria":
                    case "Croatia":
                    case "Cyprus":
                    case "Czech Republic":
                    case "Denmark":
                    case "Estonia":
                    case "Finland":
                    case "France":
                    case "Germany":
                    case "Greece":
                    case "Hungary":
                    case "Ireland":
                    case "Italy":
                    case "Latvia":
                    case "Lithuania":
                    case "Luxembourg":
                    case "Malta":
                    case "Netherlands":
                    case "Poland":
                    case "Portugal":
                    case "Romania":
                    case "Slovakia":
                    case "Slovenia":
                    case "Spain":
                    case "Sweden":
                    case "United Kingdom":
                        return true;
                    default:
                        return false;

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the county
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetCountry(this HttpRequestBase request)
        {
            try
            {
                var country = Reader.Country(request.UserHostAddress);

                return country.Country.Name;

            }
            catch (Exception)
            {
                return request.UserHostAddress;
            }
        }
    }
}