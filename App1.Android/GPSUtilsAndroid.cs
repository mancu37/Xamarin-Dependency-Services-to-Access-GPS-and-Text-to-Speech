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

using Xamarin.Forms;
using Android.Gms.Common;
using System.Threading.Tasks;

using Android.Gms.Location;

[assembly: Dependency(typeof(App1.Droid.GPSUtilsAndroid))]

namespace App1.Droid
{
    public class GPSUtilsAndroid: App1.Interfaces.IGPSUtil
    {
        public GPSUtilsAndroid() { }

        public Dictionary<int, string> IsGooglePlayServicesInstalled()
        {
            var dic = new Dictionary<int, string>();

            var queryResult = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(Forms.Context);

            if (queryResult == ConnectionResult.Success)
            {
                //Log.Info("MainActivity", "Google Play Services is installed on this device.");

                dic.Add(0, "Google Play Services is installed on this device.");

                return dic;
            }

            if (GoogleApiAvailability.Instance.IsUserResolvableError(queryResult))
            {
                // Check if there is a way the user can resolve the issue
                var errorString = GoogleApiAvailability.Instance.GetErrorString(queryResult);
                //Log.Error("MainActivity", "There is a problem with Google Play Services on this device: {0} - {1}", queryResult, errorString);

                // Alternately, display the error to the user.

                dic.Add(0, errorString);

                return dic;
            }

            return dic;
            
        }


        public async Task<string> GetLastLocationFromDevice()
        {
            // This method assumes that the necessary run-time permission checks have succeeded.
            FusedLocationProviderClient fusedLocationProviderClient;
            fusedLocationProviderClient = LocationServices.GetFusedLocationProviderClient(Forms.Context);

            Task<Android.Locations.Location> location =  fusedLocationProviderClient.GetLastLocationAsync();

            var ret = await location;

            if (ret == null)
            {
                // Seldom happens, but should code that handles this scenario
            }
            else
            {
                // Do something with the location 

            }

            return ret != null ? ret.Latitude.ToString() : "Objeto Location empty.";
        }
    }
}