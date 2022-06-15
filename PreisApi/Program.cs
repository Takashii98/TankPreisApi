// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using RestSharp;
using System.Net;

//Console.WriteLine("Hello, World!");
//API KEY Tank
//c1efe843-5d14-87ef-d804-6104e1450889
//53.638810228260084, 14.030599993787295
//https://creativecommons.tankerkoenig.de/json/list.php?lat=53.638&lng=14.030&rad=1.5&sort=dist&type=all&apikey=c1efe843-5d14-87ef-d804-6104e1450889 

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

string GetReleases(string url)
{
    var client = new RestClient(url);
    var response = client.Execute(new RestRequest());
    return response.Content;

    
    
}

try
{
    Console.Clear();
    var url = "https://creativecommons.tankerkoenig.de/json/list.php?lat=53.638&lng=14.030&rad=1.5&sort=dist&type=all&apikey=c1efe843-5d14-87ef-d804-6104e1450889";
    //var url = "https://creativecommons.tankerkoenig.de/json/list.php?lat=52.521&lng=13.438&rad=1.5&sort=dist&type=all&apikey=00000000-0000-0000-0000-000000000002";
    var url1 = "https://creativecommons.tankerkoenig.de/json/prices.php?ids=4429a7d9-fb2d-4c29-8cfe-2ca90323f9f8,446bdcf5-9f75-47fc-9cfa-2c3d6fda1c3b,60c0eefa-d2a8-4f5c-82cc-b5244ecae955,44444444-4444-4444-4444-444444444444&apikey=00000000-0000-0000-0000-000000000002";
    
    //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(url1);
    Root account = JsonConvert.DeserializeObject<Root>(GetReleases(url));
    foreach (var item in account.stations)
    {
        Console.WriteLine("Name: " + item.brand + " - " + item.name);
        Console.WriteLine("Diesel: " + item.diesel);
        Console.WriteLine("Super e5: " + item.e5);
        Console.WriteLine("Super e10: " + item.e10);
        Console.WriteLine("Geöffnet: " + item.isOpen);
    }

    Console.ReadLine();


}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Root
{
    //public bool ok { get; set; }
    //public string license { get; set; }
    //public string data { get; set; }
    //public string status { get; set; }
    public List<Station> stations { get; set; }
}

public class Station
{
    public string id { get; set; }
    public string name { get; set; }
    public string brand { get; set; }
    public string street { get; set; }
    public string place { get; set; }
    public double lat { get; set; }
    public double lng { get; set; }
    public double dist { get; set; }
    public double diesel { get; set; }
    public double e5 { get; set; }
    public double e10 { get; set; }
    public bool isOpen { get; set; }
    public string houseNumber { get; set; }
    public int postCode { get; set; }
}



