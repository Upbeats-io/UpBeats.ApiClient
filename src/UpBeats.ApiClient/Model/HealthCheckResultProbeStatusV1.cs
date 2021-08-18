namespace UpBeats.ApiClient.Model
{
    using System.Collections.Generic;

    public class HealthCheckResultProbeStatusV1
    {
        /// <summary>
        /// Identifier to differentiate probes within the service
        /// </summary>
        public string ProbeName { get; set; }

        /// <summary>
        /// The underlying type used to perform the test (optional)
        /// </summary>
        public string ProbeType { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The duration elapsed to perform the probe test (optional)
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// The status of the probe
        /// </summary>
        public SeverityLevel Level { get; set; }

        /// <summary>
        /// Short summary of the probe status (optional)
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Detailed information that can be used to diagnose failures. (optional)
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Additional key/value information to provide extra context.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }
    }
}