namespace UpBeats.ApiClient
{
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    internal static class HttpContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this System.Net.Http.HttpContent content)
        {
            return JsonConvert.DeserializeObject<T>(await content.ReadAsStringAsync());
        }
    }
}