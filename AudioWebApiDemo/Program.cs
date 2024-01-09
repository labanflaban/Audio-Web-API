﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using AudioWebApiDemo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
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

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    //endpoints.MapGet("/artists",(context) =>
    //{
    //    var artists = app.Services.GetService<IArtistService>().Get();
    //    var json = JsonSerializer.Serialize<IEnumerable<Artist>>(artists.Result);
    //    return context.Response.WriteAsync(json);
    //});
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id}");

app.Run();
