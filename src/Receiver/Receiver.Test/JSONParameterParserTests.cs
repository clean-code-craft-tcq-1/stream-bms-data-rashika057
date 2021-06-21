using System;
using System.Collections.Generic;
using Xunit;

namespace Receiver.Test
{
    public class JSONParameterParserTests
    {
        public static IEnumerable<object[]> Parameters =>
        new List<object[]>
        {
            new object[] {
                new List<string>{ "{\"temperature\":15.23,\"soc\":59.92}",
                "{\"temperature\":2.16,\"soc\":6.37}",
                "{\"temperature\":36.56,\"soc\":13.96}",
                "{\"temperature\":98.68,\"soc\":46.43}",
                "{\"temperature\":93.65,\"soc\":63.09}",
                "{\"temperature\":64.15,\"soc\":11.02}",
                "{\"temperature\":85.31,\"soc\":67.39}",
                "{\"temperature\":18.56,\"soc\":57.88}",
                "{\"temperature\":89.02,\"soc\":64.91}",
                "{\"temperature\":74.76,\"soc\":11.27}",
                "{\"temperature\":66.31,\"soc\":16.3}",
                "{\"temperature\":33.01,\"soc\":56.89}"
            }
            }
        };

        //Arrange
        JSONParameterParser jsonParameterParser = new JSONParameterParser();

        [Theory(DisplayName = "JSON Parser returns parameters")]
        [MemberData(nameof(Parameters))]
        public void Parser_ListOfJSONString_ReturnsListOfBatteryParameters(List<string> parameterData)
        {
            //Act
            List<BatteryParameters> batteryParameters = jsonParameterParser.Parser(parameterData);

            //Assert
            Assert.True(batteryParameters.Count > 0 && batteryParameters[0].StateOfCharge > 0
                && batteryParameters[0].Temperature > 0);
        }

        [Fact(DisplayName = "JSON Parser returns zero parameters")]
        public void Parser_EmptyList_ReturnsZeroBatteryParametersList()
        {
            //Act
            List<BatteryParameters> batteryParameters = jsonParameterParser.Parser(new List<string> { });

            //Assert
            Assert.True(batteryParameters.Count == 0);
        }

        [Fact(DisplayName = "JSON Parser returns exception")]
        public void Parser_NullList_ReturnsZeroBatteryParametersList()
        {
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => jsonParameterParser.Parser(null));
        }
    }
}
