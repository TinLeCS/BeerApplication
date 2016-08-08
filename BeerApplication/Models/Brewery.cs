using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace BeerApplication.Models
{
    public class Item {
        public string id { get; set; }
        public string name { get; set; }
    }
    public class Brewery
    {
        public int currentPage { get; set; }
        public int numberOfPages { get; set; }
        public int totalResults { get; set; }
        public List<Item> data { get; set; }
        public async Task<string> GetLocation(string id)
        {
            var Locations = new Location();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.brewerydb.com");
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"/v2/brewery/{id}/locations/?key=675278d4bd9514d5cd8066f6c5ae50d7").Result;
            if (response.IsSuccessStatusCode)
            {

                Locations = await response.Content.ReadAsAsync<Location>();
            }
            try
            {
                var city = Locations.data.FirstOrDefault().locality;
                return (city.Equals("")) ? "Unknown" : city;
            }
            catch
            {
                var city = "Unknow";
                return (city.Equals("")) ? "Unknown" : city;
            }
            
        }
    }


}