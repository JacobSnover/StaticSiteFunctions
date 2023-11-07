using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StaticSiteFunctions.Infrastructure.Services;

namespace StaticSiteFunctions.Functions
{
    public static class GetBlogsFunction
    {
        [FunctionName("GetBlogsFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var blogService = new BlogService();
            var blogs = await blogService.GetBlogs();

            return new OkObjectResult(blogs);
        }
    }
}
