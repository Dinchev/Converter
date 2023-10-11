using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XMltoJson.Models;
using XMltoJson.Helper;

namespace XMltoJson.Controllers
{
    public class HomeController : Controller
    {
        private readonly FileConverter _fileConverter = new FileConverter();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Uploader(IFormFileCollection FilesList, string OutputPath)
        {
            //var filelist = HttpContext.Request.Form.Files;
            if (FilesList.Count == 0)
            {
                ViewBag.Message = "Please select a file.";
                return View("Index");
            }
            if (string.IsNullOrEmpty(OutputPath?.Trim()))
            {
                ViewBag.Message = "Output folder path empty. Please add a valid path.";
                return View("Index");
            }
            if (!Directory.Exists(OutputPath))
            {
                ViewBag.Message = "Output folder path does not exist. Please add a valid path.";
                return View("Index");
            }
            var convertionStatus = new List<string>();
            foreach (var file in FilesList)
            {
                string fileName = file.FileName;
                if (string.IsNullOrEmpty(fileName))
                {
                    ViewBag.Message = "Invalid file";
                    return View("Index");
                }
                var nameArray = fileName.Split('.').ToArray();
                if (nameArray.Last() != "xml")
                {
                    ViewBag.Message = "Invalid file format.";
                    return View("Index");
                }
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                convertionStatus.Add(this.ConvertFile(file, OutputPath).Result);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
            var filesStatus = string.Join(", ", convertionStatus);
            ViewBag.Message = $"{filesStatus}";
            return View("Index");
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<string> ConvertFile(IFormFile file, string outputPath)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var jsonFileName = file.FileName.Replace(".xml", ".json");
            var json = _fileConverter.ConvertToJson(file);
            if (string.IsNullOrEmpty(json))
            {
                return $"{file.FileName}: Invalid file content";
            }
            System.IO.File.WriteAllText($@"{outputPath}\{jsonFileName}", json);
            return $"{file.FileName}: successfully converted";
        }
    }
}