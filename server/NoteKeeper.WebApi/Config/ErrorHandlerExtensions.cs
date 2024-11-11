using System.Net;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace NoteKeeper.WebApi.Config
{
    public static class ErrorHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseExceptionHandler(builder =>
            {
                builder.Run(async httpContext =>
                {
                    var gerenciadorDeExcecoes = httpContext.Features.Get<IExceptionHandlerFeature>();

                    if(gerenciadorDeExcecoes is null) return;

                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpContext.Response.ContentType = "application/json";

                    var objeto = new
                    {
                        Sucesso = false,
                        Erros = new string[] { "Erro interno do servidor." }
                    };

                    var respostaJson = JsonSerializer.Serialize(objeto);

                    await httpContext.Response.WriteAsync(respostaJson);

                });
            });
        }
    }
}
