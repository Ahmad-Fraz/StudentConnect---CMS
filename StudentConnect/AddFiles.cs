using System.Security.Claims;

namespace StudentConnect
{
    public class AddFiles
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly HttpContextAccessor httpContext;

        public AddFiles( IWebHostEnvironment webHostEnvironment,HttpContextAccessor httpContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContext = httpContext;
        }

        public IFormFile? FormFile { get; set; }
      

        private string AddFile(FormFile formFile)
        {
            string filename = null;
            if (formFile != null)
            {

                string folder = "Profile_Pics/";
                filename = (Guid.NewGuid().ToString()) + " " + formFile.FileName;
                string path = folder + filename;

                string serverPath = Path.Combine(webHostEnvironment.WebRootPath, path);

                formFile.CopyTo(new FileStream(serverPath, FileMode.Create));
            }
            return filename;
        }

        public string GetId()
        {
            return httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
