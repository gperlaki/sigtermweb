using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Travix.Platform.FlightApi.WebService
{
    public class ApplicationLifetimeHostedService : IHostedService
    {
        private Microsoft.AspNetCore.Hosting.IApplicationLifetime appLifetime;

        public ApplicationLifetimeHostedService(Microsoft.AspNetCore.Hosting.IApplicationLifetime appLifetime)
        {
            this.appLifetime = appLifetime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now} - {Environment.MachineName} - SIGTERM received");

            return Task.CompletedTask;
        }

        private void OnStarted()
        {
        }

        private void OnStopping()
        {
            Console.WriteLine($"{DateTime.Now} - {Environment.MachineName} - OnStopping ... Will take ~10s...");

            Thread.Sleep(10 * 1000);
        }

        private void OnStopped()
        {
            Console.WriteLine($"{DateTime.Now} - {Environment.MachineName} - OnStopped");
        }
    }
}