using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            var tacoParser = new TacoParser();
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.528193, -84.363476, Taco Bell Jonesboro...", -84.363476)]
        [InlineData("34.820847, -87.681448, Taco Bell Florence...", -87.681448)]
        [InlineData("30.459515, -84.35516, Taco Bell Tallahassee...", -84.35516)]
        [InlineData("33.569202,-84.540661,Taco Bell Union Cit...", -84.540661)]

        public void ShouldParseLongitude(string line, double expected)
        {
           
            var tacoParser = new TacoParser();
            var actual = tacoParser.Parse(line).Location.Longitude;
            Assert.Equal(expected.ToString(), actual.ToString());
        }


        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("33.528193, -84.363476, Taco Bell Jonesboro...", 33.528193)]
        [InlineData("34.820847, -87.681448, Taco Bell Florence...", 34.820847)]
        [InlineData("30.459515, -84.35516, Taco Bell Tallahassee...", 30.459515)]
        [InlineData("33.569202, -84.540661, Taco Bell Union Cit...", 33.569202)]

        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser = new TacoParser();
            var actual = tacoParser.Parse(line).Location.Latitude;
            Assert.Equal(expected.ToString(), actual.ToString());

        }

    }
}
