using System.Collections.Generic;

namespace CheckImHere.Models
{
    public class Event
    {
        public string CampusName { get; set; }

        public string ContactEmail { get; set; }

        public string ContactName { get; set; }

        public string Description { get; set; }

        public bool HasCoverImage { get; set; }

        public string Location { get; set; }

        public string Name { get; set; }

        public string OrganizationName { get; set; }

        public string OrganizationUri { get; set; }

        public string PhotoLink { get; set; }

        public string RsvpLink { get; set; }

        public string StartDateTimeUtc { get; set; }

        public string Subdomain { get; set; }

        public List<string> Tags { get; set; }

        public string Uri { get; set; }
    }
}