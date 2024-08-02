using DemoPWA4;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;





//Register Syncfusion license
//Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NBaF1cXmhPYVZpR2Nbe05xfldPalhVVBYiSV9jS3pTc0dqWHxceXBRQmdfUg==");
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzMyMzI4MEAzMjM2MmUzMDJlMzBKYUJPNUVCMzg2WXQ3K0RKYzFJOHBtRSt2SDU3WXVRMjZINnBzNGQyOG5ZPQ==");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSyncfusionBlazor();

AppDomain.CurrentDomain.SetData("ContentRootPath", builder.HostEnvironment);
//AppDomain.CurrentDomain.SetData("WebRootPath", builder.HostEnvironment.WebRootPath);

await builder.Build().RunAsync();
