using System;

public class OpHttpClasses
{
    internal class OpHttpClasses()
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
