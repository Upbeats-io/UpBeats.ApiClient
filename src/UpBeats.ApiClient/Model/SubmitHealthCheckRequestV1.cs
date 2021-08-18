using System;
using System.Collections.Generic;

namespace UpBeats.ApiClient.Model
{
    public class SubmitHealthCheckRequestV1
    {
        /// <summary>
        /// The UTC timestamp representing when the healthcheck was performed
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Unique identifier for the service.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Version number of the service
        /// </summary>
        public string ServiceVersion { get; set; }

        /// <summary>
        /// Identifier used to differentiate multiple instances of the same service
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// Overall healthcheck status level
        /// </summary>
        public SeverityLevel Level { get; set; }

        /// <summary>
        /// The total duration elapsed when performing the health checks (optional)
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// The results for the tests performed by individual probes (optional)
        /// </summary>
        public List<HealthCheckResultProbeStatusV1> Probes { get; set; } = new List<HealthCheckResultProbeStatusV1>();
    }
}
