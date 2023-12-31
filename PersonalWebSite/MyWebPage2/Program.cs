using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MyWebPage2.Data;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);
//DataBase
string DataBase = builder.Configuration.GetSection("DefaultConnection").GetValue<string>("DataBase");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<UserServices>();
//builder.Services.AddSingleton(DataBase);


builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
