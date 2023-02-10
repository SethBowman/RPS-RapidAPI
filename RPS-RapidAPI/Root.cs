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

}