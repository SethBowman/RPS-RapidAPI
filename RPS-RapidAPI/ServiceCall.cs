using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_RapidAPI
{
   public class ServiceCall
    {
        public static Root CallApi(string answer, string apiKey)
        {
            var client = new RestClient($"https://rock-paper-scissors9.p.rapidapi.com/?choice={answer}");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", $"{apiKey}");
            request.AddHeader("X-RapidAPI-Host", "rock-paper-scissors9.p.rapidapi.com");
            var response = client.Execute(request);
            var root = JsonConvert.DeserializeObject<Root>(response.Content);
            return root;
        }
    }
}
