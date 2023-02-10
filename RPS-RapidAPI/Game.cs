namespace RPS_RapidAPI
{
    public class Game
    {
        public static void Execute()
        {
            UserInteraction.PassMessage("Rock, Paper, or Scissors?");

            var answer = UserInteraction.PlayerChoice(UserInteraction.GetUserAction());

            var root = ServiceCall.CallApi(answer, Startup.GrabKey());

            UserInteraction.PassMessage($"Player 1: {answer}, Player 2 : {root.Ai.Name}\nResult of game: {root.Result}");
        }
    }
}
