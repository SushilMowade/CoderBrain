using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CoderBrain.Models
{

    public class HttpClientHelper<TRequest, TResponse>
    {
        public async Task<TResponse> CallApi(string url, TRequest body, string method)
        {
            TResponse response = default(TResponse);
            string baseUrl = AppSettings.AppSetting["SiteSettings:ApiBasePath"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage data = null;
                    if (method == "GET")
                    {
                        //GET Method  
                        data = await client.GetAsync(url);
                    }
                    else
                    {
                        if (method == "POST")
                        {
                            data = await client.PostAsJsonAsync(url, body);
                        }
                    }

                    if (data != null && data.IsSuccessStatusCode)
                    {
                        response = await data.Content.ReadAsAsync<TResponse>();
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return response;
        }
    }

       
}
