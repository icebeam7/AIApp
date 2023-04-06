using AIApp.Services;

Console.WriteLine("Welcome. Press 1 if you want to ask a question, or 2 to generate an image");
var option = Console.ReadLine();

Console.WriteLine("Please provide a prompt");
var prompt = Console.ReadLine();

var answer = string.Empty;
var service = new OpenAIService();

switch (option)
{
	case "1":
		answer = await service.AskQuestion(prompt);
		break;
	case "2":
		answer = await service.CreateImage(prompt);
		break;
	default:
		break;
}

Console.WriteLine($"The answer is: " + answer);

Console.WriteLine("Press a key to finish");
Console.ReadKey();