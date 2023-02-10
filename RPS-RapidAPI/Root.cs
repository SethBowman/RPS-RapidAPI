using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

public class Root
{
    public static string Game()
    {
        //Extract CW()s into a static class called UserInteraction and have this in a
        //method like UserInteraction.PassMessage(message)
        Console.WriteLine("Rock, Paper, or Scissors?");

        //This needs to be a method in another class, maybe called Startup
        //This part only needs to run one time so have it run at the startup of the app
        //and then never again
        //from here to
        var key = File.ReadAllText("appsettings.json");
        var apiKey = JObject.Parse(key).GetValue("DefaultKey").ToString();
        //here

        var answer = Console.ReadLine().ToLower(); //extract Console.ReadLine().ToLower() into it's own method like GetUserAction();

        //This needs to be a method in another class, maybe create a ServiceCall class
        //and this would be in a method called RetrieveAIChoice or something. 
        //pass answer and apikey as params
        //from here to 
        var client = new RestClient($"https://rock-paper-scissors9.p.rapidapi.com/?choice={answer}");
        var request = new RestRequest();
        request.AddHeader("X-RapidAPI-Key", $"{apiKey}");
        request.AddHeader("X-RapidAPI-Host", "rock-paper-scissors9.p.rapidapi.com");
        var response = client.Execute(request);
        var root = JsonConvert.DeserializeObject<Root>(response.Content);
        // here


        /*This should be in a method that would be called inside GetUserAction()
        to check their input
        Also in it's current form, you are checking to make sure the user
        typed the correct thing after sending the request
        so if you send the request then ask them to resubmit
        but they change their answer it would get really weird.
        like if you chose scissors initially but changed it to paper after,
        "you chose paper, AI chose paper, you win!".
        Furthermore, if you select something that is NOT paper, rock, or scissors
        the entire application breaks*/
        while (answer != "rock" && answer != "paper" && answer != "scissors")
        {
            Console.WriteLine("That was not an option, try again.");
            answer = Console.ReadLine().ToLower();
        }

        return $"Player 1: {answer}, Player 2 : {root.Ai.Name}\nResult of game: {root.Result}";
    }

    //Personal preference but I like properties at the top of the class file
    [JsonProperty("user")]
    public User User { get; set; }

    [JsonProperty("ai")]
    public Ai Ai { get; set; }

    [JsonProperty("result")]
    public string Result { get; set; }
}