using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using todo_api.Entities;

namespace todo_api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      // CreateWebHostBuilder(args).Build().Run();
      var host = CreateWebHostBuilder(args).Build();

      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;

        try
        {
          var context = services.GetRequiredService<TodoContext>();
          // GO TO THE METHOD ONBUILDERCREATING
          context.Database.EnsureCreated();
        }
        catch (Exception e)
        {
          var logger = services.GetRequiredService<ILogger<Program>>();
          logger.LogError(e, "An error ocurred creating the DB.");
        }
      }
      host.Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
  }
}
