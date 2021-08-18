namespace UpBeats.ApiClient
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    partial class UpBeatsApiClient
    {
        private HttpClient Client { get; set; }

        private async Task<TSuccess> GetAsync<TSuccess>(Uri uri, Dictionary<string, string> additionalHeaders = null)
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = uri,
                Method = HttpMethod.Get,
            };
            request.AppendAdditionalHeaders(additionalHeaders);

            return await this.SendRequest<TSuccess>(request);
        }

        private async Task<TSuccess> DeleteAsync<TSuccess>(
            Uri uri,
            Dictionary<string, string> additionalHeaders = null)
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = uri,
                Method = HttpMethod.Delete,
            };
            request.AppendAdditionalHeaders(additionalHeaders);
            return await this.SendRequest<TSuccess>(request);
        }

        private async Task<TSuccess> PostAsync<TPayload, TSuccess>(
            Uri uri,
            TPayload payload,
            Dictionary<string, string> additionalHeaders = null)
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = uri,
                Content = this.CreateStringContent<TPayload, TSuccess>(payload),
                Method = HttpMethod.Post,
            };
            request.AppendAdditionalHeaders(additionalHeaders);
            return await this.SendRequest<TSuccess>(request);
        }

        private async Task<TSuccess> PutAsync<TPayload, TSuccess>(
            Uri uri,
            TPayload payload,
            Dictionary<string, string> additionalHeaders = null)
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = uri,
                Content = this.CreateStringContent<TPayload, TSuccess>(payload),
                Method = HttpMethod.Put,
            };
            request.AppendAdditionalHeaders(additionalHeaders);
            return await this.SendRequest<TSuccess>(request);
        }

        private StringContent CreateStringContent<TPayload, TSuccess>(TPayload payload)
        {
            return new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
        }

        private async Task<TSuccess> SendRequest<TSuccess>(HttpRequestMessage request)
        {
            var result = await this.Client.SendAsync(request).ConfigureAwait(false);

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsAsync<TSuccess>();
            }

            throw await this.CreateFailureException(result);
        }

        private async Task<Exception> CreateFailureException(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            return new ApiException(response.StatusCode, responseContent);
        }
    }
}