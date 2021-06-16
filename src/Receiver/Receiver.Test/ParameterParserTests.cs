using System;
using System.Collections.Generic;
using Xunit;

namespace Receiver.Test
{
    public class ParameterParserTests
    {
        public static IEnumerable<object[]> Parameters => JSONParameterParserTests.Parameters;

        [Fact(DisplayName = "Parameter Parser returns Exception")]
        public void ParameterParserCtor_Null_ReturnsException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => new ParameterParser(null));
        }

        [Theory(DisplayName = "Parameter Parser returns parameters")]
        [MemberData(nameof(Parameters))]
        public void Parser_ListOfJsonString_ReturnsListOfBatteryParameters(List<string> parameterData)
        {
            //Arrange
            var parameterParser = new ParameterParser(new JSONParameterParser());

            //Act
            List<BatteryParameters> batteryParameters = parameterParser.Parser(parameterData);

            //Assert
            Assert.True(batteryParameters.Count > 0 && batteryParameters[0].StateOfCharge > 0
                && batteryParameters[0].Temperature > 0);
        }
    }
}
