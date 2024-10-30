using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optix.Domain.Library.Models
{
    internal class OpHttpClasses
    {
        internal static async Task<T> HttpGetMethodAsync<T>(Uri uri)
        {
            string apiResponse = string.Empty;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        apiResponse = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        //Handle error
                    }
                }
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(apiResponse);
        }
    }
}
