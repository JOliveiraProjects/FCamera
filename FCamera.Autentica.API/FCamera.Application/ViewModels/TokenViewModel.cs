using Newtonsoft.Json;
using System;

namespace FCamera.Application.ViewModels
{
    [JsonObject("Token")]
    public class TokenViewModel
    {
        [JsonProperty("auth_token")]
        public string AuthToken { get; set; }

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        [JsonProperty("token_type")]
        public string TokenType
        {
            get
            {
                return "Bearer";
            }
        }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
