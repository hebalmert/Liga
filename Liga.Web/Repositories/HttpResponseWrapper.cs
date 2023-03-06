using System.Net;

namespace Liga.Web.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        public bool Error { get; set; }

        public T Response { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null!;
            }

            var StatusCode = HttpResponseMessage.StatusCode;
            if (StatusCode == HttpStatusCode.NotFound)
            {
                return "The Resouce isn't Found";
            }
            else if (StatusCode == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            else if (StatusCode == HttpStatusCode.Unauthorized)
            {
                return "Most to go Login to access this Opperation.";
            }
            else if (StatusCode == HttpStatusCode.Forbidden)
            {
                return "You aren't authorized to access this Site";
            }

            return "Some Plablem has happens";
        }
    }
}
