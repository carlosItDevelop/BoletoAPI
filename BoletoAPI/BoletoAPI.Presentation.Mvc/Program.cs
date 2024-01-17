using BoletoAPI.Infrastructure.CossCutting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SDTEC.GestorEducacional.Models;
using Microsoft.AspNetCore.Http;
using DinkToPdf.Contracts;
using DinkToPdf;

namespace SDTEC.GestorEducacional
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.Configure<SmartSettings>(builder.Configuration.GetSection(SmartSettings.SectionName));
            builder.Services.AddSingleton(s => s.GetRequiredService<IOptions<SmartSettings>>().Value);


            builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));


            // Add services to the container.
            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            builder.Services.AddRazorPages();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                    "intel",
                    "{controller=intel}/{action=analyticsdashboard}");

            app.MapRazorPages();

            app.Run();
        }

    }
}
