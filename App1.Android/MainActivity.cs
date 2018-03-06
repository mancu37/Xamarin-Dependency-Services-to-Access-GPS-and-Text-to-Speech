using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Location;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;
using Android.Support.Design.Widget;
using Xamarin.Forms;

namespace App1.Droid
{
    [Activity(Label = "App1", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {



            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) == (int)Permission.Granted)
            {
                // We have permission, go ahead and use the camera.
            }
            else
            {
                // Camera permission is not granted. If necessary display rationale & request.

                if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.AccessFineLocation))
                {
                    // Provide an additional rationale to the user if the permission was not granted
                    // and the user would benefit from additional context for the use of the permission.
                    // For example if the user has previously denied the permission.


                    var requiredPermissions = new String[] { Manifest.Permission.AccessFineLocation };

                    var activity = (Activity)Forms.Context;
                    var view = activity.FindViewById(Android.Resource.Id.Content);


                    Snackbar.Make(view,
                                   "Permitir a esta aplicacion acceso al GPS.",
                                   Snackbar.LengthIndefinite)
                            .SetAction("OK",
                                       new Action<Android.Views.View>(delegate (Android.Views.View obj) {
                                           ActivityCompat.RequestPermissions(this, requiredPermissions, 1);
                                       }
                            )
                    ).Show();

                    
                }
                else
                {
                    ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessFineLocation }, 1);
                }

            }

            //if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) == (int)Permission.Granted)
            //{
            //    // We have permission, go ahead and use the camera.
            //}
            //else
            //{
            //    // Camera permission is not granted. If necessary display rationale & request.
            //}
        }
    }
}

