namespace xml_to_json_tests
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Text;
    using System.Threading.Tasks;
    using XMltoJson.Controllers;

    public class Tests
    {
        private static Class1 _class1 = new Class1();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task MissingFile()
        {
            HomeController controller = new HomeController();
            var outputPath = @"D:\New folder (3)\";
            var result = controller.Uploader(new FormFileCollection(), outputPath);
            Assert.IsTrue(File.Exists($"{outputPath}FirstTest.xml"));
        }

        [Test]
        public async Task MissingOutputFolder()
        {
            HomeController controller = new HomeController();
            var outputPath = @"";
            var filesList = _class1.GetSingleFile();
            var result = controller.Uploader(filesList, outputPath);
            Assert.IsTrue(File.Exists($"{outputPath}FirstTest.json"));
        }

        [Test]
        public async Task InvalidOutputFolder()
        {
            HomeController controller = new HomeController();
            var outputPath = @"D:\New fol\";
            var filesList = _class1.GetSingleFile();
            var result = controller.Uploader(filesList, outputPath);
            Assert.IsTrue(File.Exists($"{outputPath}FirstTest.json"));
        }

        [Test]
        public async Task SingleFile()
        {
            HomeController controller = new HomeController();
            var outputPath = @"D:\New folder (3)\";
            var filesList = _class1.GetSingleFile();
            var result = controller.Uploader(filesList, outputPath);
            Assert.IsTrue(File.Exists($"{outputPath}FirstTest.json"));
        }

        [Test]
        public async Task SingleInvalidFile()
        {
            HomeController controller = new HomeController();
            var outputPath = @"D:\New folder (3)\";
            var filesList = _class1.GetInvalidFile();
            var result = controller.Uploader(filesList, outputPath);
            Assert.IsFalse(File.Exists($"{outputPath}FirstTest - Copy (3).json"));
        }

        [Test]
        public async Task MultipleFiles()
        {
            HomeController controller = new HomeController();
            var outputPath = @"D:\New folder (3)\";
            var filesList = _class1.GetFiles();
            var result = controller.Uploader(filesList, outputPath);
            //Assert.IsTrue(result.Status == TaskStatus.RanToCompletion);
            Assert.IsTrue(File.Exists($"{outputPath}FirstTest - Copy.json"));
            Assert.IsTrue(File.Exists($"{outputPath}FirstTest - Copy (2).json"));
            Assert.IsTrue(File.Exists($"{outputPath}FirstTest.json"));
        }

        [Test]
        public async Task MultipleFilesWithInvalid()
        {
            HomeController controller = new HomeController();
            var outputPath = @"D:\New folder (3)\";
            var filesList = _class1.GetFiles();
            filesList.AddRange(_class1.GetInvalidFile());
            var result = controller.Uploader(filesList, outputPath);
            //Assert.IsTrue(result.Status == TaskStatus.RanToCompletion);
            Assert.IsTrue(File.Exists($"{outputPath}FirstTest - Copy.json"));
            Assert.IsTrue(File.Exists($"{outputPath}FirstTest - Copy (2).json"));
            Assert.IsFalse(File.Exists($"{outputPath}FirstTest - Copy (3).json"));
            Assert.IsTrue(File.Exists($"{outputPath}FirstTest.json"));
        }

    }
}