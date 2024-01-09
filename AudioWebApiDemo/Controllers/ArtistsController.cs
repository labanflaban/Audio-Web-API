using AudioWebApiDemo.Models;
using AudioWebApiDemo.Pages;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;

namespace AudioWebApiDemo.Controllers
{
    public class ArtistsController : Controller
    {
        
        [HttpGet]
        public IActionResult Index(string searchArtist)
        {

            var artist = getArtistFromAPI(searchArtist).Result;
            return View(artist);
        }
        
        public async Task<Artist> getArtistFromAPI(string artistInput)
        {
            //var searchedArtist = Request.Query.FirstOrDefault(q => q.Key.Equals("name")).Value;
            using var client = new HttpClient()
            {
                BaseAddress = new Uri("https://theaudiodb.p.rapidapi.com")
            };
            
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "1b3ec1e580mshff5a91450a7fcc0p14660djsn011a1c884c5d");

            var artists = await client.GetFromJsonAsync<Response>($"/search.php?s={artistInput}");
            var artist = artists.Artists.FirstOrDefault();
            string jsonString = "";
            //Checks if input is valid
            if (artist.idArtist == null)
            {
                //should return exception
            }
            else
            {
                var options = new JsonSerializerOptions();
                options.WriteIndented = true;
                jsonString = System.Text.Json.JsonSerializer.Serialize<Artist>(artists.Artists[0], options);

            }
            return artist;
        }
    }
}