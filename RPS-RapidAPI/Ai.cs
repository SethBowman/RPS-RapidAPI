﻿using Newtonsoft.Json;

public class Ai
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("beats")]
    public string Beats { get; set; } 
}