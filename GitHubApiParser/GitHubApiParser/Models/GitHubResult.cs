using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubApiParser.Models
{
    public class GitHubResult
    {
        public string login { get; set; }
        public int id { get; set; }
        public string avatar_url { get; set; }
        public string repos_url { get; set; }
        public string location { get; set; }
        public string message { get; set; }
    }
}