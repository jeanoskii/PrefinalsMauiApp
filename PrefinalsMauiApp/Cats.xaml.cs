using Newtonsoft.Json;

namespace PrefinalsMauiApp;

public partial class Cats : ContentPage
{
    // TASK: GET A RANDOM CAT IMAGE AND DISPLAY TO USER

    // Cat API documentation link:
    // https://developers.thecatapi.com/view-account/ylX4blBYT9FaoVd6OhvR?report=bOoHBz-8t

    // Step 1. Create an HttpClient
    //      in this example, the HttpClient object is named 'client'
    public HttpClient client = new HttpClient();

    // Step 2. Create a global variable that will hold the
    //      base URL of the API
    public string baseURL = "https://api.thecatapi.com/";

    // Step 3. Create a global variable that will hold the
    //      JSON response from the API call/request
    public string response;

    // Step 4. Create a class based on the JSON response
    //      You can use https://json2csharp.com/ to convert
    //      the JSON schema to a .NET class
    //      actual JSON response from endpoint https://api.thecatapi.com/v1/images/search
    //      [   {   "id":"<string cat id>",
    //              "url":"<string image url>",
    //              "width":<integer width>,
    //              "height":<integer height>   }   ]
    public class RandomCatImage
    {
        public string id { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }


    public Cats()
	{
		InitializeComponent();
	}

    // Step 5. Create a method that will do the actual API call/request
    public async void FetchRandomCatImage()
    {
        // Step 6. Create a string for the endpoint of the API call
        string endpoint = baseURL + "v1/images/search";
        
        // Step 7. assign the JSON response to the variable 'response'
        //          using the GetStringAsync() method of the HttpClient object
        response = await client.GetStringAsync(endpoint);
    }

    // Step 8. Create the Button Click event
    private void btnFetch_Clicked(object sender, EventArgs e)
    {
        // Step 9. Call the method that we created earlier
        //          to fetch the random cat image
        FetchRandomCatImage();

        // Step 10. Check if the response is null
        if (response != null)
        {
            // Step 11. Create a RandomCatImage object named
            //      'randomCat'
            List<RandomCatImage> randomCat;

            // Step 12. Using the global variable 'response', which again
            //          holds the JSON response, call the 'DeserializeObject' method
            //          from Newtonsoft.JsonConvert object.
            //          DeserializeObject will try to convert the JSON object response
            //          to the indicated .NET object which is RandomCatImage
            randomCat = JsonConvert.DeserializeObject<List<RandomCatImage>>(response);

            // Step 13. After the JSON response has been assigned to the
            //          randomCat object, we will assign the imgCats.Source
            //          to randomCat.url property
            imgCats.Source = randomCat[0].url;
        }
    }
}