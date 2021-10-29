using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SendWelcomeEmail
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void IninitializeClient(Boolean bProdChecked)
        {

            ApiClient = new HttpClient();
            if (bProdChecked == true)
            {
                ApiHelper.ApiClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["enrollmentURLProduction"]);
            }
            else
            {
                ApiHelper.ApiClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["enrollmentURLSandbox"]);
            }
            
            ApiClient.DefaultRequestHeaders.Accept.Clear();

            if (bProdChecked == true)
            {
                ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ConfigurationManager.AppSettings["tokenProduction"]);
            }
            else
            {
                ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ConfigurationManager.AppSettings["tokenSandbox"]);
            }
            

            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


    }
}
