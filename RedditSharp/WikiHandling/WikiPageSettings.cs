﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using RedditSharp.Contracts;
using RedditSharp.Things;

namespace RedditSharp
{
    public class WikiPageSettings
    {
        [JsonProperty("listed")]
        public bool Listed { get; set; }

        [JsonProperty("permlevel")]
        public int PermLevel { get; set; }

        [JsonIgnore]
        public IEnumerable<RedditUser> Editors { get; set; }

        public WikiPageSettings()
        {
        }

        protected internal WikiPageSettings(IReddit reddit, JToken json, IWebAgent webAgent)
        {
            var editors = json["editors"].ToArray();
            Editors = editors.Select(x => new RedditUser().Init(reddit, x, webAgent));
            JsonConvert.PopulateObject(json.ToString(), this, reddit.JsonSerializerSettings);
        }
    }
}