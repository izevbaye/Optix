using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WireMock.Admin.Mappings;
using System.Text.Json;

namespace Optix.Domain.Library.Models
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;
            ResponseModel exModel = new ResponseModel();

            switch (exception)
            {
                case ApplicationException ex:
                   
                    break;
                case FileNotFoundException ex:
                    
                    break;
                default:
                   
                    break;

            }
            var exResult = JsonSerializer.Serialize(exModel);
            await context.Response.WriteAsync(exResult);
        }
    }
}
