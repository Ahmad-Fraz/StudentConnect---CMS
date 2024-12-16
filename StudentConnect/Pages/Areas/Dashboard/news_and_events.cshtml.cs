using Encapsulation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Models.Dashboard;

namespace StudentConnect.Pages.Areas.Dashboard
{
    public class news_and_eventsModel : PageModel
    {
        private readonly Interface @interface;

        [BindProperty]
        public news_events News_Events { get; set; }

        public news_and_eventsModel(Interface @interface)
        {
            this.@interface = @interface;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {

            return Page();
        }
    }
}