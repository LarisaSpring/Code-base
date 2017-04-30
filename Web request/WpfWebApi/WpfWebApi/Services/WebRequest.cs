using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xaml;
using Newtonsoft.Json;

namespace WpfWebApi.Services
{
    public class WebRequest
    {
        //http://json2csharp.com/

        public async Task<string> GetListOfUsers()
        {
            var uri = new Uri("https://api.github.com/users");
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Me!");
            var jsonString = await httpClient.GetStringAsync(uri);
            RootObject[] root = JsonConvert.DeserializeObject<RootObject[]>(jsonString);
            return jsonString;
        }

        public class RootObject
        {
            public string login { get; set; }
            public int id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }
    }
}