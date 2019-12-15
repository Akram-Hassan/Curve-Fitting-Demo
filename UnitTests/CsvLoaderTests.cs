using AppServices;
using System;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class CsvLoaderTests
    {
        [Fact]
        public void TestProcessLines()
        {
            var lines = new string[]
            {
                "1,2",
                "-3,-4",
                "50,600"
            };

            var tupels = CsvLoader.ProcessLines(lines).ToArray();

            Assert.Equal(1, tupels[0].Item1);
            Assert.Equal(-4, tupels[1].Item2);
            Assert.Equal(50, tupels[2].Item1);
        }

        [Fact]
        public void TestCsvLineFormatting()
        {
            Assert.True(CsvLoader.LineValid("1,2"));
            Assert.True(CsvLoader.LineValid("1,20000"));
            Assert.False(CsvLoader.LineValid("1,21,"));
        }

        [Fact]
        public void TestFileErrorHandling()
        {

        }
    }
}
