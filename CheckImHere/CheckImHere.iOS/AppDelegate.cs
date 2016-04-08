using Autofac;
using Foundation;
using UIKit;
using Xamarin.Forms;
using XLabs.Forms;
using XLabs.Ioc;
using XLabs.Ioc.Autofac;
using XLabs.Platform.Device;

namespace CheckImHere.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : XFormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

            if (!Resolver.IsSet)
            {
                SetIoc();
            }

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        private void SetIoc()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => AppleDevice.CurrentDevice).As<IDevice>();

            Resolver.SetResolver(new AutofacResolver(builder.Build()));
        }
    }
}