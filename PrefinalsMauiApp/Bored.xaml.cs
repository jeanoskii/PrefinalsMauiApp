using Newtonsoft.Json;

namespace PrefinalsMauiApp;

public partial class Bored : ContentPage
{
    // TASK: GET A RANDOM ACTIVITY STRING AND DISPLAY TO USER VIA LABEL

    // Cat API documentation link:
    // https://www.boredapi.com/documentation

    // Step 1. Create an HttpClient
    //      in this example, the HttpClient object is named 'client'
    public HttpClient client = new HttpClient();

    // Step 2. Create a global variable that will hold the
    //      base URL of the API
    public string baseURL = "https://www.boredapi.com/api/";

    // Step 3. Create a global variable that will hold the
    //      JSON response from the API call/request
    public string response;

    // Step 4. Create a class based on the JSON response
    //      You can use https://json2csharp.com/ to convert
    //      the JSON schema to a .NET class
    public class RandomBored
    {
        public string activity { get; set; }
        public string type { get; set; }
        public int participants { get; set; }
        public double price { get; set; }
        public string link { get; set; }
        public string key { get; set; }
        public double accessibility { get; set; }
    }

    public Bored()
	{
		InitializeComponent();
	}

    // Step 5. Create a method that will do the actual API call/request
    public async void GetRandomActivity()
    {
        // Step 6. Create a string for the endpoint of the API call
        string endpoint = baseURL + "activity/";

        // Step 7. assign the JSON response to the variable 'response'
        //          using the GetStringAsync() method of the HttpClient object
        response = await client.GetStringAsync(endpoint);
    }

    // Step 8. Create the Button Click event
    private void btnBored_Clicked(object sender, EventArgs e)
    {
        // Step 9. Call the method that we created earlier
        //          to fetch the random activity
        GetRandomActivity();

        // Step 10. Check if the response is null
        if (response != null)
        {
            // Step 11. Create a RandomBored object named
            //      'randomBored'
            RandomBored randomBored;

            // Step 12. Using the global variable 'response', which again
            //          holds the JSON response, call the 'DeserializeObject' method
            //          from Newtonsoft.JsonConvert object.
            //          DeserializeObject will try to convert the JSON object response
            //          to the indicated .NET object which is RandomBored
            randomBored = JsonConvert.DeserializeObject<RandomBored>(response);

            // Step 13. After the JSON response has been assigned to the
            //          randomBored object, we will assign the lblActivity.Text
            //          to randomBored.activity property
            lblActivity.Text = randomBored.activity;
        }
    }
}