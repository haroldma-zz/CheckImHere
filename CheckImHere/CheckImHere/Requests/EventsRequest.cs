using CheckImHere.Responses;
using Portable.FluentRest.Extensions;

namespace CheckImHere.Requests
{
    public class EventsRequest : CheckImHereBaseRequest<EventsResponse>
    {
        public EventsRequest() : base("events")
        {
            this.Get();
        }
    }
}