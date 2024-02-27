using Microsoft.Extensions.DependencyInjection;
using PreCiseMeetingContentDelivery;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

// Load meeting info according to the way specified in the configuration settings (currently use file-based storage)
var fileOption = builder.Configuration.GetSection(nameof(StorageOption)).Get<StorageOption>();

// Create a singleton of the meeting info that will be shared through lifetime of application.
IMeetingInfo meetingInfo = new FileMeetingInfo(fileOption?.FileName, fileOption?.TimeZone);
builder.Services.AddSingleton<IMeetingInfo>(meetingInfo);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
