using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web_AdminLTE_Bootstrap_4_dotNet_Indetify.Data;

[assembly: HostingStartup(typeof(Web_AdminLTE_Bootstrap_4_dotNet_Indetify.Areas.Identity.IdentityHostingStartup))]
namespace Web_AdminLTE_Bootstrap_4_dotNet_Indetify.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}