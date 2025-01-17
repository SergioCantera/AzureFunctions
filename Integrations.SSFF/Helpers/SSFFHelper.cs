﻿using SSFFIntegration.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SSFFIntegration.Helpers
{
    public static class SSFFHelper
    {
        public static async Task<string> GetToken()
        {
            using (var client = new HttpClient())
            {
                string endPointURL = "https://your_domain/learning/oauth-api/rest/v1/token";

                var content = @"{ ""grant_type"":""client_credentials"",
                    ""scope"":{
                        ""userId"":""userId"",
                        ""companyId"":""company1"",
                        ""userType"":""user"",
                        ""resourceType"":""learning_public_api""
                    }
                }";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "Token_for_connecting_ssff");

                var response = await client.PostAsync(endPointURL, new StringContent(content));

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    TokenModel responseObject = JsonSerializer.Deserialize<TokenModel>(responseBody);

                    return responseObject.access_token;
                }
            }
            
            return string.Empty;
        }

        public static async Task<string> GetLearningPlan(string accessToken, string targetUserID)
        {
            using (var client = new HttpClient())
            {
                string endPointURL = string.Format("https://your_domain/learning/odatav4/public/user/learningplan-service/v1/UserTodoLearningItems?$filter=criteria/targetUserID eq '{0}' and criteria/includeDeeplink eq true", targetUserID);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await client.GetAsync(endPointURL);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
            }

            return null;
        }
    }
}
