using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubApiParser.Models
{
    public class UserInfo
    {

        public int ID { get; set; }
        public string UserName { get; set; }
        public string Location { get; set; }
        public string AvatarUrl { get; set; }
        public List<string> TopRepos { get; set; }

    }
}