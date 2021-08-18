namespace UpBeats.ApiClient
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    internal static class HttpRequestMessageExtensions
    {
        public static void AppendAdditionalHeaders(this HttpRequestMessage message, IDictionary<string, string> additionalHeaders)
        {
            if (additionalHeaders != null && additionalHeaders.Any())
            {
                foreach (var item in additionalHeaders)
                {
                    message.Headers.Add(item.Key, item.Value);
                }
            }
        }
    }
}