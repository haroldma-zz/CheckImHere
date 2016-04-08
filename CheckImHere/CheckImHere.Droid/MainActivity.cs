using Android.App;
using Android.Content.PM;
using Android.OS;
using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XLabs.Ioc;
using XLabs.Ioc.Autofac;
using XLabs.Platform.Device;

namespace CheckImHere.Droid
{
    [Activity(Label = "Check I'm Here", Theme = "@style/CheckImHereTheme", Icon = "@drawable/icon", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            if (!Resolver.IsSet)
            {
                SetIoc();
            }

            LoadApplication(new App());
        }

        private void SetIoc()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => AndroidDevice.CurrentDevice).As<IDevice>();

            Resolver.SetResolver(new AutofacResolver(builder.Build()));
        }
    }
}