using System;
using System.Net.Http;
using HttpTracer;
using SecureHttpClient;

namespace Issue13.Api.Services
{
    public abstract class BaseApiService
    {
        static readonly string[] CertificatePins = { @"sha256/fxf7kzJ2eD+yjn1GfHWRkHU24U297K69jSfvf387A0c=" };

        public static HttpClient CreateHttpClient(string url)
        {
            HttpClient client;
            Uri baseAddress = new Uri(url);

            var innerHandler = new SecureHttpClientHandler(null);
            innerHandler.UseProxy = false;
            innerHandler.AddCertificatePinner(baseAddress.Host, CertificatePins);
#if DEBUG
            var verbosity = HttpMessageParts.RequestBody | HttpMessageParts.RequestHeaders | HttpMessageParts.ResponseBody;
            client = new HttpClient(new HttpTracerHandler(innerHandler, verbosity));
#else
            client = new HttpClient(innerHandler);
#endif
            client.BaseAddress = baseAddress;
            client.Timeout = TimeSpan.FromSeconds(60);

            return client;
        }
    }
}