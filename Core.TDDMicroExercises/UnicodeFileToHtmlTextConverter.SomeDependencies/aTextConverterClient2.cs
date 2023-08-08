using System;
namespace Core.TDDMicroExercises.UnicodeFileToHtmlTextConverter.SomeDependencies
{
    public class aTextConverterClient2
    {
		// A class with the only goal of simulating a dependency on UnicodeFileToHtmTextConverter
		// that has impact on the refactoring.


		UnicodeFileToHtmlTextConverterClass _textConverter;

        public aTextConverterClient2()
        {
            string filePath = "anotherFilename.txt";
            IFileReader fileReader = new FileReader(filePath);

            UnicodeFileToHtmlTextConverterClass converter = new UnicodeFileToHtmlTextConverterClass(fileReader);

            string htmlContent = converter.ConvertToHtml();
        }

    }
}
    