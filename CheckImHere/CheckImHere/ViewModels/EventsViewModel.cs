using System.Collections.Generic;
using System.Linq;
using CheckImHere.Models;
using CheckImHere.Requests;
using CheckImHere.Responses;
using XLabs.Forms.Mvvm;

namespace CheckImHere.ViewModels
{
    internal class EventsViewModel : NavigationAwareViewModel
    {
        private List<Event> _events;
        private Dictionary<string, bool> _organizations;
        private PortalResponse _portal;
        private Dictionary<string, bool> _tags;
        private List<Event> _unfiltered;

        public List<Event> Events
        {
            get
            {
                return _events;
            }
            set
            {
                SetProperty(ref _events, value);
            }
        }

        public Dictionary<string, bool> Organizations
        {
            get
            {
                return _organizations;
            }
            set
            {
                SetProperty(ref _organizations, value);
            }
        }

        public PortalResponse Portal
        {
            get
            {
                return _portal;
            }
            set
            {
                SetProperty(ref _portal, value);
            }
        }

        public Dictionary<string, bool> Tags
        {
            get
            {
                return _tags;
            }
            set
            {
                SetProperty(ref _tags, value);
            }
        }

        public override async void OnViewAppearing()
        {
            IsBusy = true;
            var response = await new PortalRequest().ToResponseAsync();
            if (response.IsSuccessStatusCode)
            {
                Portal = response.DeserializedResponse;
            }

            var eventsResponse = await new EventsRequest().ToResponseAsync();
            IsBusy = false;
            if (!eventsResponse.IsSuccessStatusCode)
            {
                return;
            }

            Events = eventsResponse.DeserializedResponse;
            _unfiltered = eventsResponse.DeserializedResponse;

            Organizations = new Dictionary<string, bool>();
            foreach (var org in Events.Select(p => p.OrganizationName).Distinct())
            {
                Organizations.Add(org, false);
            }
            Tags = new Dictionary<string, bool>();
            foreach (var org in Events.SelectMany(p => p.Tags).Distinct())
            {
                Tags.Add(org, false);
            }
        }

        public void RefreshFilters()
        {
            var filtered = _unfiltered;
            // Apply organizational filter if any is set
            if (Organizations.Any(p => p.Value))
                filtered = filtered.Where(p => Organizations[p.OrganizationName]).ToList();

            // Apply tag filter if any is set
            if (Tags.Any(p => p.Value))
                filtered = filtered.Where(p => p.Tags.Any(m => Tags[m])).ToList();

            Events = filtered;
        }
    }
}