using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
namespace autoaccess.scriptables
{
    public class PowerIndicator
    {
public static bool IsCharging
        {
            get;
            private set;
        }
    public static bool IsFull
        {
            get;
            private set;
        }
        public static bool IsNotPresent
        {
            get;
            private set;
        }
        public double GetBatteryInfo()
    {   
        var state = Battery.State;
           switch (state)
            {
                case BatteryState.Charging:
                    IsCharging = true;
                    break;
                case BatteryState.Full:
                    IsFull = true;
                    break;
                case BatteryState.Discharging:
                case BatteryState.NotCharging:
                    IsCharging = false;
                    break;
                case BatteryState.NotPresent:
                        case BatteryState.Unknown:
                    return -1;
            }
            return Math.Floor(Battery.ChargeLevel * 100);
        }//func
    }//class
}//namespace
