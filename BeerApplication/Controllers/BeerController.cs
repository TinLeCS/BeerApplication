using BeerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BeerApplication.Controllers
{
    public class BeerController : Controller
    {

        // GET: Beer
        public async Task<ActionResult> GetBreweries()
        {
            var Breweries = new Brewery();
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://api.brewerydb.com");
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/v2/breweries?established=2009&key=675278d4bd9514d5cd8066f6c5ae50d7").Result;
            if (response.IsSuccessStatusCode)
            {

                Breweries = await response.Content.ReadAsAsync<Brewery>();
            }
            return View(Breweries);
        }
    }
}
