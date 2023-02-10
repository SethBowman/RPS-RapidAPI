using Newtonsoft.Json.Linq;

namespace RPS_RapidAPI
{
    public class Startup
    {
        public static string GrabKey()
        {
            var key = File.ReadAllText("appsettings.json");
            var apiKey = JObject.Parse(key).GetValue("DefaultKey").ToString();

            return apiKey;
        }
    }
}
