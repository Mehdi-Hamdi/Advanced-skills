using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyAPIApp;

public class MyProgram
{
     static void Main(string[] args)
    {
        var restClient = new RestClient("https://api.agify.io"); //RestClient handles base URL

        var restRequest = new RestRequest(); //Makes the HTTP Request

        //Building the request
        restRequest.Method = Method.Get;
        restRequest.AddHeader("Content-Type", "application/json");
        restRequest.Timeout = -1; 

        string name = "jasser";

        restRequest.Resource = $"?name={name}";

        var nameResponse =  restClient.Execute(restRequest);

        Console.WriteLine(nameResponse.Content);
    }
}