using System.IO;
using System.Text;
using System.Web;

namespace Core.TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    using System.IO;
    using System.Web;

    public class UnicodeFileToHtmlTextConverterClass
    {
        private readonly IFileReader _fileReader;

        public UnicodeFileToHtmlTextConverterClass(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public string ConvertToHtml()
        {
            using (TextReader unicodeFileStream = _fileReader.OpenText())
            {
                string html = string.Empty;

                string line = unicodeFileStream.ReadLine();
                while (line != null)
                {
                    html += HttpUtility.HtmlEncode(line);
                    html += "<br />";
                    line = unicodeFileStream.ReadLine();
                }

                return html;
            }
        }
    }

}
