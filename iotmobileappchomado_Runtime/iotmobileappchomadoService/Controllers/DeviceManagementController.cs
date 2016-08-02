﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iotmobileappchomadoService.Controllers
{
    using System.Threading.Tasks;
    public class DeviceManagementController : ApiController
    {
        string IoTHubEndpoint = "[IoT Hub Endpoint]";
        string RegistryRWKey = "[Registry Read/Write Key]";
        public async Task<DeviceRegistration> Get()
        {
            var dr = new DeviceRegistration()
            {
                DeviceKey = "",
                IoTHubEndpoint = "",
                HasRegisted = false
            };
            try
            {
                var deviceId = this.Request.Headers.GetValues("device-id").ElementAt(0);
                string IoTHubConnectionString = "HostName=" + IoTHubEndpoint + ";SharedAccessKeyName=registryReadWrite;SharedAccessKey=" + RegistryRWKey;
                var registryManager = Microsoft.Azure.Devices.RegistryManager.CreateFromConnectionString(IoTHubConnectionString);
                await registryManager.OpenAsync();
                Microsoft.Azure.Devices.Device device = null;
                try
                {
                    device = await registryManager.GetDeviceAsync(deviceId);
                    dr.HasRegisted = true;
                }
                catch (Exception ex)
                {
                    device = new Microsoft.Azure.Devices.Device(deviceId);
                    device = await registryManager.AddDeviceAsync(device);
                }
                if (device != null)
                {
                    dr.DeviceKey = device.Authentication.SymmetricKey.PrimaryKey;
                    dr.IoTHubEndpoint = IoTHubEndpoint;
                }
                await registryManager.CloseAsync();

                this.ResponseMessage(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                dr.Status = ex.Message;
                this.ResponseMessage(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
            return dr;
        }

    }
    public class DeviceRegistration
    {
        public bool HasRegisted { get; set; }
        public string IoTHubEndpoint { get; set; }
        public string DeviceKey { get; set; }
        public string Status { get; set; }
    }
}
