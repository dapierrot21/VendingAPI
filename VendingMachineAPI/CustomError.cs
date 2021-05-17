using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace VendingMachineAPI
{
    public class HttpError : IHttpActionResult
    {
        private readonly string message;
        private readonly HttpRequestMessage request;

        public HttpError(string message, HttpRequestMessage request)
        {
            this.message = message;
            this.request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
                var response = new HttpResponseMessage
                {
                    StatusCode = (HttpStatusCode) 422,
                    RequestMessage = this.request,
                    Content = new StringContent(this.message)
                };

                return Task.FromResult(response);
        }
    }
}