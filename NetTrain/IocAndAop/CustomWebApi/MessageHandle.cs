using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace IocAndAop.CustomWebApi
{
    public class MessageHandle: DelegatingHandler
    {

        protected async override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            Debug.WriteLine("This is web api handle Process request.");
            // Call the inner handler.
            var response = await base.SendAsync(request, cancellationToken);
            Debug.WriteLine("This is web api handle Process response.");
            return response;
        }
    }
}