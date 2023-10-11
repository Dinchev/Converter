using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Analytics.UserId;
using XMltoJson.Controllers;

namespace xml_to_json_tests
{
    internal class Class1
    {
        public FormFileCollection GetFiles()
        {
            var content = File
                .ReadAllText(@"C:\GitLab\FileConverter\xml-to-json-tests\TestFiles\FirstTest.xml");
            var fileName = "FirstTest.xml";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;
            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
            var content2 = File
                .ReadAllText(@"C:\GitLab\FileConverter\xml-to-json-tests\TestFiles\FirstTest - Copy.xml");
            var fileName2 = "FirstTest - Copy.xml";
            var stream2 = new MemoryStream();
            var writer2 = new StreamWriter(stream2);
            writer2.Write(content2);
            writer2.Flush();
            stream2.Position = 0;
            //create FormFile with desired data
            IFormFile file2 = new FormFile(stream2, 0, stream2.Length, "id_from_form", fileName2);
            var content3 = File
                .ReadAllText(@"C:\GitLab\FileConverter\xml-to-json-tests\TestFiles\FirstTest - Copy (2).xml");
            var fileName3 = "FirstTest - Copy (2).xml";
            var stream3 = new MemoryStream();
            var writer3 = new StreamWriter(stream3);
            writer3.Write(content3);
            writer3.Flush();
            stream3.Position = 0;
            //create FormFile with desired data
            IFormFile file3 = new FormFile(stream3, 0, stream3.Length, "id_from_form", fileName3);

            FormFileCollection formFiles = new FormFileCollection();
            formFiles.Add(file);
            formFiles.Add(file2);
            formFiles.Add(file3);
            return formFiles;
        }

        public FormFileCollection GetSingleFile()
        {
            var content = File.ReadAllText(@"C:\GitLab\FileConverter\xml-to-json-tests\TestFiles\FirstTest.xml");
            //var content = "Hello World from a Fake File";
            var fileName = "FirstTest.xml";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;
            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
            FormFileCollection formFiles = new FormFileCollection();
            formFiles.Add(file);
            
            return formFiles;
        }

        public FormFileCollection GetInvalidFile()
        {
            var content = File.ReadAllText(@"C:\GitLab\FileConverter\xml-to-json-tests\TestFiles\FirstTest - Copy (3).xml");
            //var content = "Hello World from a Fake File";
            var fileName = "FirstTest - Copy (3).xml";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;
            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
            FormFileCollection formFiles = new FormFileCollection();
            formFiles.Add(file);

            return formFiles;
        }

        public async Task Upload_ReadsFileStream()
        {
            //var content = File.ReadAllText(@"C:\GitLab\FileConverter\xml-to-json-tests\TestFiles\FirstTest.xml");
            ////var content = "Hello World from a Fake File";
            //var fileName = "FirstTest.xml";
            //var stream = new MemoryStream();
            //var writer = new StreamWriter(stream);
            //writer.Write(content);
            //writer.Flush();
            //stream.Position = 0;

            ////create FormFile with desired data
            //IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
            //HomeController uploadController = new HomeController();
            //await uploadController.ConvertFile(file, @"D:\New folder (3)");

            // Get a loose automock
            //var Mock = AutoMock.GetLoose();
            //var expectedFileContents = File.ReadAllText(@"D:\New folder (3)\FirstTest.xml");
            //// Set up the form file with a stream containing the expected file contents
            //Mock<IFormFile> formFile = new Mock<IFormFile>();

            //formFile.Setup(ff => ff.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
            //  .Returns<Stream, CancellationToken>((s, ct) =>
            //  {
            //      byte[] buffer = Encoding.Default.GetBytes(expectedFileContents);
            //      s.Write(buffer, 0, buffer.Length);
            //      return Task.CompletedTask;
            //  });
            //formFile.Setup(f => f.FileName).Returns("FirstTest.xml");
            //// Set up the form collection with the mocked form
            //Mock<IFormCollection> forms = new Mock<IFormCollection>();
            //forms.Setup(f => f.Files[It.IsAny<int>()]).Returns(formFile.Object);

            //// Create the Upload Contoller
            //var uploadController = Mock.Create<HomeController>();

            // Set up the context
            // uploadController.ControllerContext = new HomeController(); 
            // Set up the forms
            // Invoke the method
            //await uploadController.ConvertFile(formFile.Object, @"D:\New folder (3)");
            //return;
            //foreach (var file in forms.Object.Files)
            //{
            //    await uploadController.ConvertFile(formFile.Object, @"D:\New folder (3)");
            //}
            //uploadController.Uploader(forms.Object.Files, @"D:\New folder (3)");

            // Verify that the File Service was called with the expected file contents
            //Mock.Mock<IFileService>().Verify(fs => fs.Import(expectedFileContents), Times.Once());
        }
    }
}
