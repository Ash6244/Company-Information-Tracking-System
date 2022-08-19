using CompanyInfoTrackingSystem.Models.DataModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyInfoTrackingSystem.Controllers
{
    public class LetterUploadController
    {
        private static IWebHostEnvironment _webHostEnvironment;
        public LetterUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [Route("Upload")]
        public async Task<string> Upload([FromForm] EmpAppraisalModel obj)
        {
            if (obj.OfferLetter.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Letters\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Letters\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Letters\\" + obj.OfferLetter.FileName))
                    {
                        obj.OfferLetter.CopyTo(filestream);
                        filestream.Flush();
                        return "\\Letter\\" + obj.OfferLetter.FileName;
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
