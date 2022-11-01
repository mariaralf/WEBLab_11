using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages
{
    public class fourthTab_upload_images_Model : PageModel
    {
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment Environment;
        public string Message { get; set; }

        public fourthTab_upload_images_Model(Microsoft.AspNetCore.Hosting.IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        public void OnGet()
        {
            Console.WriteLine("GET");
        }


        public void Aboba()
        {
            Console.WriteLine("aboba");
        }

  


      
       

    }
}

