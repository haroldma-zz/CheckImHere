using ModernHttpClient;
using Portable.FluentRest.Extensions;
using Portable.FluentRest.Http;

namespace CheckImHere.Requests
{
    public abstract class CheckImHereBaseRequest<T> : RestRequestObject<T>
    {
        public const string BaseApiPath = "https://atlantis.checkimhere.com/api/";
        protected CheckImHereBaseRequest(string path)
        {
            this.Handler(new NativeMessageHandler()).Url(BaseApiPath + path);
        }
    }
}