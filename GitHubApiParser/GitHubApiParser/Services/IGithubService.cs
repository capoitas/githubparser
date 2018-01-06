using GitHubApiParser.Models;

namespace GitHubApiParser.Services
{
    public interface IGithubService
    {
        UserInfo GetUserInfo(string searchText);
    }
}