using Android.Content;
using Xamarin.Forms;
using Android.Support.V4.Content;

[assembly: Dependency(typeof(App1.Droid.GoogleMapsAndroid))]
namespace App1.Droid
{
    public class GoogleMapsAndroid : App1.Interfaces.IGoogleMaps
    {
        public GoogleMapsAndroid(){}

        public void LaunchMap(double lat, double lng)
        {
            var geoUri = Android.Net.Uri.Parse(string.Format("geo:{0},{1}", lat, lng));
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            Forms.Context.StartActivity(mapIntent);
        }

    }
}