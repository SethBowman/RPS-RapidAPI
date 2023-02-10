
namespace RPS_RapidAPI
{
    public static class UserInteraction
    {
        public static void PassMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetUserAction()
        {
            return Console.ReadLine().ToLower();
        }

        public static string PlayerChoice(string answer)
        {
            while (answer != "rock" && answer != "paper" && answer != "scissors")
            {
                PassMessage("That was not an option, try again.\n(Rock, Paper, or Scissors?)");
                answer = GetUserAction();
                Console.Clear();
            }
            return answer;
        }

        public static void PlayGame()
        {
            var answer = "yes";
            while (answer == "yes")
            {
                PassMessage("Would you like to play Rock, Paper, Scissors? (Type yes or no)");
                answer = GetUserAction();
                Console.Clear();
                while (answer != "yes" && answer != "no")
                {
                    PassMessage("That was not an option, try again.\n(Type yes to continue or no to quit)");
                    answer = GetUserAction();
                    Console.Clear();
                }
                if (answer == "yes")
                {
                    Root.Game();
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    PassMessage("So long, partner!");
                }

            }
        }
    }
}
