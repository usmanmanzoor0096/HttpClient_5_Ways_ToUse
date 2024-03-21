using System.Web;

namespace httpClient_5_Ways_ToUse
{
    public class AppendQueryHandler : DelegatingHandler
    {
        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri != null)
            {
               string url= request.RequestUri.ToString();
                var uriBuilder = new UriBuilder(url);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["myQuery"] = "usman";
                uriBuilder.Query = query.ToString();
                url= uriBuilder.ToString();
                request.RequestUri = new Uri(url);
            }

            //request.Headers.Add(); /// we can append header here for all nested api calls.
            return base.Send(request, cancellationToken);
        }
    }
}
