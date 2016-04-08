using System;
using CheckImHere.ViewModels;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace CheckImHere.Views
{
    public partial class EventsView
    {
        public EventsView()
        {
            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private void Organizations_OnClicked(object sender, EventArgs e)
        {
            var vm = (EventsViewModel)BindingContext;

            var stack = new StackLayout();
            foreach (var organization in vm.Organizations)
            {
				var checkbox = new Switch
                {
					IsToggled = organization.Value
                };

				checkbox.Toggled += (o, args) =>
                    {
                        vm.Organizations[organization.Key] = !vm.Organizations[organization.Key];
                        vm.RefreshFilters();
                    };

				stack.Children.Add(new StackLayout{
					Orientation = StackOrientation.Horizontal,
					Children = { checkbox, new Label { Text = organization.Key } }
				});
            }

            ShowPopup(stack);
        }

        private void ShowPopup(View content)
        {
            var popLayout = new ScrollView
            {
                WidthRequest = 250,
                Padding = 10,
                BackgroundColor = Color.White,
                Content = content,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var bg = Color.Black;
            bg = bg.MultiplyAlpha(.5);

            var popup = new Grid
            {
                Children = { popLayout },
                Padding = 25,
                BackgroundColor = bg,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => RootGrid.Children.Remove(popup);
            popup.GestureRecognizers.Add(tapGestureRecognizer);

			RootGrid.Children.Add(popup);
        }

        private void Tags_OnClicked(object sender, EventArgs e)
        {
            var vm = (EventsViewModel)BindingContext;

            var stack = new StackLayout();
			foreach (var tag in vm.Tags)
			{
				var checkbox = new Switch
				{
					IsToggled = tag.Value
				};

				checkbox.Toggled += (o, args) =>
				{
					vm.Tags[tag.Key] = !vm.Tags[tag.Key];
					vm.RefreshFilters();
				};

				stack.Children.Add(new StackLayout{
					Orientation = StackOrientation.Horizontal,
					Children = { checkbox, new Label { Text = tag.Key } }
				});
			}
            ShowPopup(stack);
        }
    }
}