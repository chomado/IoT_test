using System;
using Microsoft.SPOT;

namespace PinKitIoTHubApp
{
    public static class IoTHoLConfig
    {
        public static string DeviceEntryEndPoint = "[MobileAppName].azurewebsites.net";
        // IoT Hub Configuration
        public static string IoTHubEndpoint = "EGIoTHoLV31chomado.azure-devices.net";
        public static string DeviceKey = "rZ9z0bQafyZoL+qshRwIH4V1sEFx6H3/MEdhs6kI0Vc=";

        // Location 
        public static double Latitude = 35.62661;
        public static double Longitude = 139.740987;
    }
}
