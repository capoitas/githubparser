using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubApiParser.Models
{
    public class GitHubResultReposList
    {
        public int id { get; set; }
        public string name { get; set; }
        public int stargazers_count { get; set; }
    }

}