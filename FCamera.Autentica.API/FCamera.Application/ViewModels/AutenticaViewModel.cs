using Newtonsoft.Json;

namespace FCamera.Application.ViewModels
{
    public class AutenticaViewModel
    {
        [JsonProperty("usuario")]
        public string Usuario { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }
    }
}
