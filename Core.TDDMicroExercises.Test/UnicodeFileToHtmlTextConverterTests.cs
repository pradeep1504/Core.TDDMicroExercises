using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using System.IO;
using Core.TDDMicroExercises.UnicodeFileToHtmlTextConverter;


namespace Core.TDDMicroExercises.Test
{
    [TestFixture]
    public class UnicodeFileToHtmlTextConverterTests
    {
        [Test]
        public void ConvertToHtml_WhenGivenFileContent_ReturnsHtmlContentWithLineBreaks()
        {
            // Arrange
            string inputText = "Hello, world!\nWelcome to\nUnit Testing.";
            string expectedHtml = "Hello, world!<br />Welcome to<br />Unit Testing.<br />";

            var mockFileReader = new Mock<IFileReader>();
            mockFileReader.Setup(reader => reader.OpenText()).Returns(new StringReader(inputText));

            var converter = new UnicodeFileToHtmlTextConverterClass(mockFileReader.Object);

            // Act
            string result = converter.ConvertToHtml();

            // Assert
            Assert.AreEqual(expectedHtml, result);
        }
    }


}
