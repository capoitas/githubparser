# GitHub Parser
ASP.Net MVC website with a search field to lookup for GitHub users/accounts. 
When the search matches a user some details are shown, like his name, location, avatar and a list with his top repositories.
The backend uses the GitHub Api to retrieve the data by parsing the JSON data from the endpoint "https://api.github.com/users/{{accountName}}".
