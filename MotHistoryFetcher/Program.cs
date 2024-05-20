using DotNetEnv;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MotHistoryFetcher;

var builder = WebApplication.CreateBuilder(args);
Env.Load();
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped(sp =>
{
    var httpClient = new HttpClient { BaseAddress = new Uri(builder.Configuration["MotHistoryBaseUrl"] ?? string.Empty) };
    httpClient.DefaultRequestHeaders.Add("x-api-key", builder.Configuration["MOT_HISTORY_API_KEY"]);
    return httpClient;
});
builder.Services.AddScoped<MotHistoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
