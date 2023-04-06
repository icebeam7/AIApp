using System.Text.Json.Serialization;

namespace AIApp.Models.Text
{
    public class CompletionRequest
    {
        public string prompt { get; set; }
        public string model { get; set; } = "text-davinci-003";
        public float temperature { get; set; } = 0.2f;
       
        public int max_tokens { get; set; } = 100;
    }
}
