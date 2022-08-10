using Octokit;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text;

Console.WriteLine("Enter github username: ");
var githubUser = Console.ReadLine();
Console.WriteLine("Enter your git credentials: ");
var gitCredentials = Console.ReadLine();
Console.WriteLine("Enter your Freshdesk subdomain: ");
var fdDomain = Console.ReadLine();
Console.WriteLine("Enter your apiKey: ");
var apiKey = Console.ReadLine();

if (githubUser != "" && gitCredentials != "" && apiKey != "" && fdDomain != "")
{
    await SystemUnderTest.DoStuffAsync(githubUser, gitCredentials, apiKey, fdDomain);
}
else Console.Write("Parameters must not be empty");

public sealed class SystemUnderTest
{
    public static async Task DoStuffAsync(string gitUser, string gitCredentials, string apiKey, string fdDomain)
    {
        var gitHubClient = new GitHubClient(new ProductHeaderValue("Test"));
        var user = await gitHubClient.User.Get(gitUser);
        gitHubClient.Credentials = new Credentials(gitCredentials);
        Console.WriteLine(user.Name);
        string username = user.Name;
        string apiPath = "/api/v2/tickets";


        RestClient client = new RestClient("https://" + fdDomain + ".freshdesk.com" + apiPath);
        client.Authenticator = new HttpBasicAuthenticator(apiKey, "X");
        RestRequest request = new RestRequest("", Method.Post);

        request.AddHeader("Accept", "application/json");

        request.AddJsonBody(new
        {
            email = "example1@example.com",
            subject = "Subject",
            description = $"The github username is: {username}, the user has {user.PublicRepos} public repos",
            name = username,
            status = 2,
            priority = 1
        });

        var response = client.Execute(request);
        Console.WriteLine(response);

        HttpStatusCode statusCode = response.StatusCode;
        int numericStatusCode = (int)statusCode;
        Console.WriteLine(statusCode.ToString());

    }
}




