using CompanyInfoTrackingSystem.Models.DataModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CompanyInfoTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoUploadController
    {
        private static IWebHostEnvironment _webHostEnvironment;
        public PhotoUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [Route("Upload")]
        public async Task<string> Upload([FromForm] EmployeeModel obj)
        {
            if (obj.Photo.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Images\\" + obj.Photo.FileName))
                    {
                        obj.Photo.CopyTo(filestream);
                        filestream.Flush();
                        return "\\Images\\" + obj.Photo.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Upload Failed";
            }
        }
    }
}
