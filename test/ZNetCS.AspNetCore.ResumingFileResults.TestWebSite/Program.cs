﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Marcin Smółka zNET Computer Solutions">
//   Copyright (c) Marcin Smółka zNET Computer Solutions. All rights reserved.
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZNetCS.AspNetCore.ResumingFileResults.TestWebSite
{
    #region Usings

    using System.IO;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

#if NETCOREAPP3_0
    using Microsoft.Extensions.Hosting;
#endif

#endregion

    /// <summary>
    /// The program to un app.
    /// </summary>
    public class Program
    {
        #region Public Methods

#if !NETCOREAPP3_0
        /// <summary>
        /// The main entry to application.
        /// </summary>
        /// <param name="args">
        /// The programs arguments.
        /// </param>
        public static void Main(string[] args)
        {
            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration(
                    (hostingContext, config) =>
                    {
                        var env = hostingContext.HostingEnvironment;
                        config.SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables();
                    })
                .ConfigureLogging(
                    (hostingContext, logging) =>
                    {
                        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                        logging.AddConsole();
                        logging.AddDebug();
                    })
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
#endif

#if NETCOREAPP3_0
        /// <summary>
        /// The host builder.
        /// </summary>
        /// <param name="args">
        /// The programs arguments.
        /// </param>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        /// <summary>
        /// The main entry to application.
        /// </summary>
        /// <param name="args">
        /// The programs arguments.
        /// </param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
#endif
        #endregion
    }
}