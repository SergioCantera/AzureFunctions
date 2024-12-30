using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using MAPFRE.SSFFIntegration.Helpers;
using System.Text.Json;
using System.Net.Http.Headers;
using MAPFRE.LearningPlan.Models;

namespace MAPFRE.SSFFIntegration
{
    public class GetLearningPlan
    {
        private readonly ILogger<GetLearningPlan> _logger;

        public GetLearningPlan(ILogger<GetLearningPlan> logger)
        {
            _logger = logger;
        }

        [Function("GetLearningPlan")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request. GetLearningPlan");

            string authorizationHeader = req.Headers["Authorization"];
            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                string token = authorizationHeader.Substring("Bearer ".Length);

                var userResponse = await GetUserDataAsync(token);


                if (userResponse.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Token JWT válido.");
                    var userData = await userResponse.Content.ReadAsStringAsync();
                    UserModel userObject = JsonSerializer.Deserialize<UserModel>(userData);

                    _logger.LogInformation("EmployeeId: " + userObject.employeeId);

                    string tokenSSFF = await SSFFHelper.GetToken();

                    var learningPlanForUser = await SSFFHelper.GetLearningPlan(tokenSSFF, userObject.employeeId);

                    return new JsonResult(JsonSerializer.Deserialize<object>(learningPlanForUser));

                }
                else
                {
                    return new  ObjectResult(userResponse.StatusCode);  
                }
            }
            else
            {
                return new BadRequestObjectResult("Token JWT no proporcionado en el encabezado Authorization.");
            }
        }

        private static async Task<HttpResponseMessage> GetUserDataAsync(string accessToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);                
                
                return await client.GetAsync("https://graph.microsoft.com/v1.0/me?$select=employeeId");
            }
        }
    }
}
