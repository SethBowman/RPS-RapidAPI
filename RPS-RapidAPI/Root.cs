using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

public class Root
{
    public static string Game()
    {
        var key = File.ReadAllText("appsettings.json");
        var apiKey = JObject.Parse(key).GetValue("DefaultKey").ToString();

        var client = new RestClient("https://rock-paper-scissors9.p.rapidapi.com/?choice=rock");
        var request = new RestRequest();
        request.AddHeader("X-RapidAPI-Key", $"{apiKey}");
        request.AddHeader("X-RapidAPI-Host", "rock-paper-scissors9.p.rapidapi.com");
        var response = client.Execute(request);
        var root = JsonConvert.DeserializeObject<Root>(response.Content);

        Console.WriteLine("Rock, Paper, or Scissors?");

        root.User.Name = Console.ReadLine().ToLower();

        while(root.User.Name != "rock" && root.User.Name != "paper" && root.User.Name != "scissors")
        {
            Console.WriteLine("That was not an option, try again.");
            root.User.Name = Console.ReadLine().ToLower();
        }

        return $"Player 1: {root.User.Name}, Player 2 : {root.Ai.Name}\nResult of game: {root.Result}";
    }
    [JsonProperty("user")]
    public User User { get; set; }

    [JsonProperty("ai")]
    public Ai Ai { get; set; }

    [JsonProperty("result")]
    public string Result { get; set; }
}