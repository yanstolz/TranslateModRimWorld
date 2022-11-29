using System;
using System.Xml;
using System.Net;
using System.Web;

namespace TranslateMod
{
    public class Translate
    {

        public void StartTranslateXML(string path)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlElement element = xml.DocumentElement;
            foreach (XmlNode xnode in element)
            {
                xnode.InnerText = TranslateWord(xnode.InnerText);
            }
            xml.Save(path);
        }

        public string TranslateWord(string word)
        {
            var toLanguage = "ru";//Русский
            var fromLanguage = "en";//Английский
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Ошибка";
            }
        }
    }
}
