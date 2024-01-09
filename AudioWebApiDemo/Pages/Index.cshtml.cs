using AudioWebApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AudioWebApiDemo.Pages
{

    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public Artist? artist { get; set; }
        
        public string searchedArtist = "";
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            //var artist = Request.Query.FirstOrDefault(q => q.Key.Equals("artist")).Value;
            searchedArtist = Request.Query.FirstOrDefault(q => q.Key.Equals("searchArtist")).Value;
            
        }
    }
}