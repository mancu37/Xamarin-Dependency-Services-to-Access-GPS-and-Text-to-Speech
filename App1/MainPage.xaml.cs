using App1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btn.Clicked += (sender, e) =>
            {
                DependencyService.Get<ITextToSpeech>().Speak(txt.Text);
            };

            Dictionary<int, string> dic;

            dic = DependencyService.Get<Interfaces.IGPSUtil>().IsGooglePlayServicesInstalled();
            txtStatus.Text = dic[0];

            

        }

        double lat;
        double lng;

        async private void btnGPS_Clicked(object sender, EventArgs e)
        {
            try
            {
                //Task<string> x =   DependencyService.Get<Interfaces.IGPSUtil>().GetLastLocationFromDevice();

                //var ret = await x;

                //txtLatitud.Text = ret;

                ILocation loc = DependencyService.Get<ILocation>();
                loc.locationObtained += (Object ss, ILocationEventArgs ee) =>
                {
                    lat = ee.lat;
                    lng = ee.lng;

                };

                loc.ObtainMyLocation();

                await Task.Delay(4000);

                txtStatus.Text = string.Format("Lat: {0} - Long: {1}", lat.ToString(), lng.ToString());

                DependencyService.Get<IGoogleMaps>().LaunchMap(lat, lng);


            }
            catch(Exception ex)
            {
                txtStatus.Text = ex.Message;
            }
        }

        async private void btnGoogleServices_Clicked(object sender, EventArgs e)
        {
            try
            {

                string lat = await DependencyService.Get<Interfaces.IGPSUtil>().GetLastLocationFromDevice();

                txtLatitud.Text = string.Format("Latitud: {0}", lat); ;    
                
                
            }
            catch (Exception ex)
            {
                txtStatus.Text = ex.Message;
            }
        }
    }
}
