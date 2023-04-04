using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
//...

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        //...
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        //...
        app.UseCors();
        //...
    }
}
