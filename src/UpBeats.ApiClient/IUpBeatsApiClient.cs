using System.Threading.Tasks;
using UpBeats.ApiClient.Model;

namespace UpBeats.ApiClient
{
    public interface IUpBeatsApiClient
    {       
        Task<SubmitHealthCheckResponseV1> SubmitHealthCheckAsync(SubmitHealthCheckRequestV1 healthCheck, string apiKey);
    }
}