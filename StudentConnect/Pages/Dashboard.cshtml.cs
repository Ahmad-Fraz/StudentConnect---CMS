using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentConnect.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ILogger<DashboardModel> _logger;

        public DashboardModel(ILogger<DashboardModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet =true)]
        public string signout_notification { get; set; }

        [BindProperty(SupportsGet = true)]
        public string signin_notification { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}