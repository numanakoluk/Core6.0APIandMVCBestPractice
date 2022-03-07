using Microsoft.AspNetCore.Diagnostics;

namespace API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        //write for IApplicationbuilder 
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                //run finishing type middleware
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    
                    exceptionFeature.

                });
            });
        }
    }
}
