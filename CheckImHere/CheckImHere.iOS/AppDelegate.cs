using Autofac;
using CheckImHere.Modules;
using Foundation;
using UIKit;
using Xamarin.Forms;
using XLabs.Forms;
using XLabs.Ioc;
using XLabs.Ioc.Autofac;
using XLabs.Platform.Device;

namespace CheckImHere.iOS
{
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

            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<ViewModelModule>();

            Resolver.SetResolver(new AutofacResolver(builder.Build()));
        }
    }
}