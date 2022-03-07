using Core.DTOs;
using Microsoft.AspNetCore.Diagnostics;
using Service.Exceptions;
using System.Text.Json;

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

                    //login inner with Switch
                    var statusCode = exceptionFeature.Error switch
                    {
                        //default "_"
                        ClientSideException => 400, _=> 500

                    };
                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);

                    //Json Cast normal to return Json but My do middleware because cast json
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));


                });
            });
        }
    }
}
