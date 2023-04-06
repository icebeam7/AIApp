using System.Text;
using System.Text.Json;
using System.Net.Http.Json;
using System.Net.Http.Headers;

using AIApp.Helpers;
using AIApp.Models.Text;
using AIApp.Models.Images;

namespace AIApp.Services
{
	public class OpenAIService
	{
		HttpClient client;
		
		JsonSerializerOptions options = new JsonSerializerOptions() 
		{ 
			PropertyNameCaseInsensitive = true 
		};

		public OpenAIService()
		{
			client = new HttpClient();
			client.BaseAddress = new Uri(OpenAIConstants.Server);
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", OpenAIConstants.Key);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<string> AskQuestion(string query)
		{
			var completion = new CompletionRequest()
			{
				prompt = query
			};

			var body = JsonSerializer.Serialize(completion);
			var content = new StringContent(body, Encoding.UTF8, "application/json");

			var response = await client.PostAsync(OpenAIConstants.CompletionsEndpoint, content);

			if (response.IsSuccessStatusCode)
			{
				var answer = await response.Content.ReadFromJsonAsync<CompletionResponse>(options);
				return answer?.choices?.FirstOrDefault()?.text;
			}

			return string.Empty;
		}

		public async Task<string> CreateImage(string query)
		{
			var generation = new GenerationRequest()
			{
				prompt = query
			};

			var body = JsonSerializer.Serialize(generation);
			var content = new StringContent(body, Encoding.UTF8, "application/json");

			var response = await client.PostAsync(OpenAIConstants.GenerationsEndpoint, content);

			if (response.IsSuccessStatusCode)
			{
				var answer = await response.Content.ReadFromJsonAsync<GenerationResponse>(options);
				return answer?.data?.FirstOrDefault()?.url;
			}

			return default;
		}
	}
}
