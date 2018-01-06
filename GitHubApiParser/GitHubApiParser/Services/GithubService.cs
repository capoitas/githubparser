using GitHubApiParser.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace GitHubApiParser.Services
{
    public class GithubService : IGithubService
    {
        HttpClient client;
        const string baseUrl = "https://api.github.com/users/";
        
        public GithubService()
        {
            client = new HttpClient();
        }

        public UserInfo GetUserInfo(string searchText)
        {
            var path = baseUrl + searchText;

            var data = _download_serialized_json_data<GitHubResult>(path);

            if ((data.message != null && data.message.Equals("Not Found")) || string.IsNullOrEmpty(data.login))
            {
                return null;
            }

            UserInfo result = new UserInfo()
            {
                ID = data.id,
                UserName = data.login,
                Location = data.location,
                AvatarUrl = data.avatar_url
            };

            if (!string.IsNullOrEmpty(data.repos_url))
            {
                List<GitHubResultReposList> repos = _download_serialized_json_data<List<GitHubResultReposList>>(data.repos_url);

                if (repos != null && repos.Any())
                {
                    result.TopRepos = repos.OrderByDescending(x => x.stargazers_count).Take(5).Select(x => x.name).ToList();
                }
            }

            return result;
        }

        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                w.Headers.Add("user-agent", "MyAgent");

                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception e) {

                }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }
}

