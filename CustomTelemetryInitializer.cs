namespace dotnet_azure_hello_world;

using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

public class CustomTelemetryInitializer : ITelemetryInitializer
{
    public void Initialize(ITelemetry telemetry)
    {
        if (string.IsNullOrEmpty(telemetry.Context.Cloud.RoleName))
        {
            //set custom role name here
            telemetry.Context.Cloud.RoleName = "hello-world";
            telemetry.Context.Cloud.RoleInstance = "hello-world";
        }
    }
}
