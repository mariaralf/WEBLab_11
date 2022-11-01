using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;

namespace RazorPagesApp.Pages
{

    public class IndexModel : PageModel
    {
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment Environment;
        public string Message { get; set; }

        public IndexModel(Microsoft.AspNetCore.Hosting.IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }


        public void OnGet()
        {
            
        }

      
        public void OnPost(List<IFormFile> postedFiles)
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "user_uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);

                if (fileName.Contains("png") || fileName.Contains("jpg") || fileName.Contains("jpeg") || fileName.Contains("webp"))
                {
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);

                        uploadedFiles.Add(fileName);


                        //this.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                    }
                }
            }
        }
    }
}
