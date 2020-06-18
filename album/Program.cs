using Microsoft.AspNetCore;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace album
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// Using Kestrel
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    /*public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseKestrel(options => options.Limits.MaxConcurrentConnections = 100)
            .Build();*/
}

public class ProtectionClass
{
    IDataProtector _protector;

    public ProtectionClass(IDataProtectionProvider provider)
    {
        _protector = provider.CreateProtector("Contoso.MyClass.v1");
    }
    public void TestCode()
    {
        Console.Write("Enter input: ");
        string input = Console.ReadLine();

        string protectedPayload = _protector.Protect(input);
        Console.WriteLine($"Protect returned: {protectedPayload}");

        string unprotectedPayload = _protector.Unprotect(protectedPayload);
        Console.WriteLine($"Unprotect returned: {unprotectedPayload}");
    }
}