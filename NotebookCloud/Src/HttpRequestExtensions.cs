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
                var ip = request.GetIp();

                var country = Reader.Country(ip.ToString());

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
                var ip = request.GetIp();

                var country = Reader.Country(ip.ToString());

                return country.Country.Name;

            }
            catch (Exception)
            {
                return "(unknown)";
            }
        }

        /// <summary>
        /// Gets the IP address of the request.
        /// This method is more useful than built in because in 
        /// some cases it may show real user IP address even under proxy.
        /// The <see cref="System.Net.IPAddress.None" /> value 
        /// will be returned if getting is failed.
        /// </summary>
        /// <param name="request">The HTTP request object.</param>
        /// <returns>IPAddress object</returns>
        public static IPAddress GetIp(this HttpRequestBase request)
        {
            string ipString;
            if (string.IsNullOrEmpty(request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
            {
                ipString = request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                ipString = request.ServerVariables["HTTP_X_FORWARDED_FOR"]
                   .Split(",".ToCharArray(),
                   StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
            }

            IPAddress result;
            if (!IPAddress.TryParse(ipString, out result))
            {
                result = IPAddress.None;
            }

            return result;
        }
    }
}