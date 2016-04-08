using System;
using System.Globalization;
using Xamarin.Forms;

namespace CheckImHere.Converters
{
    public class EventPhotoLinkConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;
            return new UriImageSource
            {
                Uri = new Uri("https://az795308.vo.msecnd.net/eventphotos/" + str)
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}