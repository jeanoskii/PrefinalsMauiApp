using Newtonsoft.Json;

namespace PrefinalsMauiApp;

public partial class Dogs : ContentPage
{
    // TASK: GET A RANDOM DOG IMAGE AND DISPLAY TO USER

    // Dog API documentation
    // https://dog.ceo/api

    // create a new HttpClient for our asnyc calls
    // to the API endpoint
    public HttpClient client = new HttpClient();

    // the base URI of the API. we will concatenate
    // the API calls/requests to this URL.
    public string baseURL = "https://dog.ceo/api/";

    // we will put the response of the API call/request to this variable
    public string response;

    public Dogs()
    {
        InitializeComponent();
    }
    private async void FetchRandomDogImage()
    {
        // attach the API request to the baseURL variable
        string endpoint = baseURL + "breeds/image/random";
        // Get the API response then assign to variable response
        response = await client.GetStringAsync(endpoint);
    }
    public class RandomDogImage
    {
        // reference the response of the API call by reading
        // its documentation.
        // Convert the JSON response into an equivalent class/object
        // API Call https://dog.ceo/api/breeds/image/random
        // JSON Response:
        // { "message": "<url of image>","status": "<status message>" }
        // Equivalent .NET class
        // public string message, public string status
        public string message { get; set; }
        public string status { get; set; }
    }

    private void btnFetch_Clicked(object sender, EventArgs e)
    {
        // call the function to get a random dog image
        FetchRandomDogImage();
        if (response != null) {
            // create a object called 'randomDog' of type 'RandomDogImage'
            RandomDogImage randomDog;
            // Using Newtonsoft.JsonConvert, we will deserialize the response
            // deserialize meaning we will 'parse' or 'translate' the response
            // from JSON to an equivalent object, which is RandomDogImage
            // after deserialization, assign to the randomDog object
            randomDog = JsonConvert.DeserializeObject<RandomDogImage>(response);
            // after parsing and assigning the JSON response to randomDog object
            // get the message property from the randomDog object
            // then assign to the XAML image control called imgDogs.Source
            imgDogs.Source = randomDog.message;
        }
    }
}