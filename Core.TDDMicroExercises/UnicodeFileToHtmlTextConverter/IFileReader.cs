using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public interface IFileReader
    {
        TextReader OpenText();
    }
    public class FileReader : IFileReader
    {
        private readonly string _filePath;

        public FileReader(string filePath)
        {
            _filePath = filePath;
        }

        public TextReader OpenText()
        {
            return File.OpenText(_filePath);
        }
    }
}
