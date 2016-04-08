using CheckImHere.Responses;
using Portable.FluentRest.Extensions;

namespace CheckImHere.Requests
{
    public class PortalRequest : CheckImHereBaseRequest<PortalResponse>
    {
        public PortalRequest() : base("app/portal")
        {
            this.Get();
        }
    }
}