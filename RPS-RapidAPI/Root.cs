using Newtonsoft.Json;
using RPS_RapidAPI;

public class Root
{
    [JsonProperty("user")]
    public User User { get; set; }

    [JsonProperty("ai")]
    public Ai Ai { get; set; }

    [JsonProperty("result")]
    public string Result { get; set; }

    public static void Game()
    {
        UserInteraction.PassMessage("Rock, Paper, or Scissors?");

        var answer = UserInteraction.PlayerChoice(UserInteraction.GetUserAction());

        var root = ServiceCall.CallApi(answer, Startup.GrabKey());

        UserInteraction.PassMessage($"Player 1: {answer}, Player 2 : {root.Ai.Name}\nResult of game: {root.Result}");
    }

}