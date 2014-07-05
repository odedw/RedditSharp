﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using RedditSharp.Contracts;
using RedditSharp.Things;

namespace RedditSharp
{
    public class WikiPage
    {
        [JsonProperty("may_revise")]
        public string MayRevise { get; set; }

        [JsonProperty("revision_date")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime? RevisionDate { get; set; }

        [JsonProperty("content_html")]
        public string HtmlContent { get; set; }

        [JsonProperty("content_md")]
        public string MarkdownContent { get; set; }

        [JsonIgnore]
        public RedditUser RevisionBy { get; set; }

        protected internal WikiPage(IReddit reddit, JToken json, IWebAgent webAgent)
        {
            RevisionBy = new RedditUser().Init(reddit, json["revision_by"], webAgent);
            JsonConvert.PopulateObject(json.ToString(), this, reddit.JsonSerializerSettings);
        }
    }
}