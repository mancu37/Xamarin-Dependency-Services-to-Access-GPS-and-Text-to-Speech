using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Locations;
using Xamarin.Forms;
using App1.Droid;

[assembly: Dependency(typeof(LocationServiceAndroid))]
namespace App1.Droid
{
    public class LocationEventArgs : EventArgs, ILocationEventArgs
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class LocationServiceAndroid : Java.Lang.Object, ILocation, ILocationListener
    {
        public event EventHandler<ILocationEventArgs> locationObtained;

        public void ObtainMyLocation()
        {
            LocationManager lm = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);
            lm.RequestLocationUpdates(LocationManager.NetworkProvider, 0, 0, this);

        }

        public void OnLocationChanged(Location location)
        {
            if (location != null)
            {
                LocationEventArgs args = new LocationEventArgs();
                args.lat = location.Latitude;
                args.lng = location.Longitude;
                locationObtained(this, args);
            }
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
        }
    }
}