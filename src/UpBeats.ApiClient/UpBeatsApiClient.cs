namespace UpBeats.ApiClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using UpBeats.ApiClient.Model;

    public partial class UpBeatsApiClient : IUpBeatsApiClient
    {
        public UpBeatsApiClient(HttpClient client)
        {
            this.Client = client;
        }

        public UpBeatsApiClient(string baseUrl = "https://api.upbeats.io")
        {
            this.Client = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl),
            };
        }

        public async Task<SubmitHealthCheckResponseV1> SubmitHealthCheckAsync(SubmitHealthCheckRequestV1 healthCheck, string apiKey)
        {
            var headers = this.BuildHeaders(apiKey);

            return await this.PostAsync<SubmitHealthCheckRequestV1, SubmitHealthCheckResponseV1>(new Uri("health-checks", UriKind.Relative), healthCheck, headers);
        }

        private Dictionary<string, string> BuildHeaders(string apiKey)
        {
            return new Dictionary<string, string>
            {
                {"X-Api-Key", apiKey}
            };
        }
    }
}
