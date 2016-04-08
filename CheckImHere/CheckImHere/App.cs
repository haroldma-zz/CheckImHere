using CheckImHere.ViewModels;
using CheckImHere.Views;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace CheckImHere
{
    public class App : Application
    {
        public App()
        {
            ViewFactory.Register<EventsView, EventsViewModel>();

            var page = ViewFactory.CreatePage<EventsViewModel, EventsView>();
            MainPage = new NavigationPage((Page)page)
			{
				BarBackgroundColor = Color.FromHex("#05b4de"),
				BarTextColor = Color.White
			};
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }
    }
}