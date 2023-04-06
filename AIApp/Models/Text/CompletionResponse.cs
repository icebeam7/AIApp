namespace AIApp.Models.Text
{
	public class CompletionResponse
	{
		public string id { get; set; }
		public List<Choice> choices { get; set; }
	}
}
