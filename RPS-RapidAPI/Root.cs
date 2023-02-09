using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

public class Root
{
    public static string Game()
    {
        Console.WriteLine("Rock, Paper, or Scissors?");

        var key = File.ReadAllText("appsettings.json");
        var apiKey = JObject.Parse(key).GetValue("DefaultKey").ToString();

        var answer = Console.ReadLine().ToLower();

        var client = new RestClient($"https://rock-paper-scissors9.p.rapidapi.com/?choice={answer}");
        var request = new RestRequest();
        request.AddHeader("X-RapidAPI-Key", $"{apiKey}");
        request.AddHeader("X-RapidAPI-Host", "rock-paper-scissors9.p.rapidapi.com");
        var response = client.Execute(request);
        var root = JsonConvert.DeserializeObject<Root>(response.Content);

        while (answer != "rock" && answer != "paper" && answer != "scissors")
        {
            Console.WriteLine("That was not an option, try again.");
            answer = Console.ReadLine().ToLower();
        }

        return $"Player 1: {answer}, Player 2 : {root.Ai.Name}\nResult of game: {root.Result}";
    }

    [JsonProperty("user")]
    public User User { get; set; }

    [JsonProperty("ai")]
    public Ai Ai { get; set; }

    [JsonProperty("result")]
    public string Result { get; set; }
}