using Newtonsoft.Json;
using RestSharp;

namespace APIExampleApp;

public class Program
{
    static void Main(string[] args)
    {
        var restClient = new RestClient("https://http.cat/");

        var restRequest = new RestRequest();
       
        restRequest.Method = Method.Get;
        restRequest.AddHeader("Content-Type", "application/json");
        restRequest.Timeout = -1;

        string statusCode = "100";

        restRequest.Resource = $"{statusCode}";

        var statusCodeResponse = restClient.Execute(restRequest);
        
        Console.WriteLine(statusCodeResponse.Content);

    }
}