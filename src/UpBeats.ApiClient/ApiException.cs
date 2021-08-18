namespace UpBeats.ApiClient
{
    using System;
    using System.Net;

    public class ApiException : Exception
    {
        public ApiException(HttpStatusCode statusCode, string responseContent) 
            : base($"Request failed with status '{statusCode:int}'")
        {
            this.StatusCode = statusCode;
            this.Response = responseContent;
        }

        public HttpStatusCode StatusCode { get; set; }

        public string Response { get; set; }
    }
}