using System;
namespace Core.TDDMicroExercises.UnicodeFileToHtmlTextConverter.SomeDependencies
{
    public class aTextConverterClient1
    {
		// A class with the only goal of simulating a dependency on UnicodeFileToHtmTextConverter
		// that has impact on the refactoring.

		public aTextConverterClient1()
        {
            var filename = "aFilename.txt";
            IFileReader fileReader = new FileReader(filename);

            UnicodeFileToHtmlTextConverterClass converter = new UnicodeFileToHtmlTextConverterClass(fileReader);

            string htmlContent = converter.ConvertToHtml();
        }
    }
}
