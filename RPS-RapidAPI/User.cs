using Newtonsoft.Json;
using RestSharp;

public class User
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("beats")]
    public string Beats { get; set; } 
}
