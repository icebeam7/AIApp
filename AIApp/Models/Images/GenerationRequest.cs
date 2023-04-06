namespace AIApp.Models.Images
{
	public class GenerationRequest
	{
		public string prompt { get; set; }

		public int n { get; set; } = 1;

		public string size { get; set; } = "512x512";
	}
}
