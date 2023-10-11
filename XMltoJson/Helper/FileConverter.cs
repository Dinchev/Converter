using Newtonsoft.Json;
using System.Xml;

namespace XMltoJson.Helper
{
    public class FileConverter
    {
        public string ConvertToJson(IFormFile file)
        {
            string json = "";
            try
            {


                XmlDocument doc = new XmlDocument();
                //var content = new StreamReader(file.OpenReadStream());
                string t;
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    t = reader.ReadToEnd();
                }
                doc.LoadXml(t);
                json = JsonConvert.SerializeXmlNode(doc);
            }
            catch (Exception ex)
            {

            }
            return json;
        }

    }
}
