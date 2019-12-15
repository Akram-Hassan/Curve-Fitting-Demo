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
                "-3,4",
                "50,600"
            };

            var tupels = CsvLoader.ProcessLines(lines).ToArray();

            Assert.Equal(1, tupels[0].Item1);
        }
    }
}
