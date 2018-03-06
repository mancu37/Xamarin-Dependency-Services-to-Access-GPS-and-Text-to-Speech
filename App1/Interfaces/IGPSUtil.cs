using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Interfaces
{
    public interface IGPSUtil
    {
        Dictionary<int, string> IsGooglePlayServicesInstalled();
        Task<string> GetLastLocationFromDevice();

        
    }
}
