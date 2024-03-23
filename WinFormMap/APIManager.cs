using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace WinFormMap
{
    enum HttpRequestType
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    #pragma warning disable CS8625
    #pragma warning disable CS8603
    internal class APIManager
    {
        private static readonly string API_URL = "http://127.0.0.1:8082/";
        private static HttpClient client = null;

        public APIManager()
        {
            client = new();
            client.BaseAddress = new Uri(API_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<bool> canConnectToAPI()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("checkStatus");
                return true;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private async Task<object> executeRequest<T>(HttpRequestType requestType, string request, T item)
        {
            if (!await canConnectToAPI())
                return null;

            HttpResponseMessage response = requestType switch
            {
                HttpRequestType.GET => await client.GetAsync(request),
                HttpRequestType.POST => await client.PostAsJsonAsync(request, item),
                HttpRequestType.PUT => await client.PutAsJsonAsync(request, item),
                HttpRequestType.DELETE => await client.DeleteAsync(request),
                _ => throw new NotImplementedException(),
            };

            if (requestType != HttpRequestType.GET)
            {
                response.EnsureSuccessStatusCode();
                return response.StatusCode;
            }

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }

            return null;
        }

        public async Task<List<PersonMovement>> getMovements()
        {
            object result = await executeRequest<List<PersonMovement>>(HttpRequestType.GET, "PersonLocation", null);
            return result != null ? (List<PersonMovement>)result : null;
        }
    }
}
