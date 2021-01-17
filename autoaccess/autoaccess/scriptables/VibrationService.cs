using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Essentials;

namespace autoaccess.scriptables
{
    public class VibrationService
    {
        public static (bool, string) Vibrate(int seconds = 0)
        {
            try
            {
                if (seconds == 0) Vibration.Vibrate();
                else
                {
                    var duration = TimeSpan.FromSeconds(seconds);
                    Vibration.Vibrate(duration);
                }
                return (true, string.Empty);
            }
            catch (FeatureNotSupportedException exc)
            {
                return (false, exc.Message);
            }
        }
        public static (bool, string) VibrateAndWait(int seconds = 0)
        {
            try
            {
                if (seconds == 0)
                    Vibration.Vibrate();
                
                else
                {
                    var duration = TimeSpan.FromSeconds(seconds);
                    Vibration.Vibrate(duration);
                    Thread.Sleep(seconds * 1000);
                }
                return (true, string.Empty);
            }
            catch (FeatureNotSupportedException exc)
            {
                return (false, exc.Message);
            }
        }

    }//class
}//namespace
