using System;
using System.Collections.Generic;
using Xunit;

namespace Receiver.Test
{
    public class ParameterStatisticsTests
    {
        public static IEnumerable<object[]> Parameters =>
        new List<object[]>
        {
            new object[] {
                new List<BatteryParameters>
                {
                    new BatteryParameters { Temperature =15.23f, StateOfCharge = 59.92f},
                    new BatteryParameters { Temperature =2.16f, StateOfCharge = 6.37f},
                    new BatteryParameters { Temperature =36.56f, StateOfCharge = 13.96f},
                    new BatteryParameters { Temperature =98.68f, StateOfCharge = 46.43f},
                    new BatteryParameters { Temperature =93.65f, StateOfCharge = 63.09f},
                    new BatteryParameters { Temperature =64.15f, StateOfCharge = 11.2f},
                    new BatteryParameters { Temperature =85.31f, StateOfCharge = 67.39f},
                    new BatteryParameters { Temperature =18.56f, StateOfCharge = 57.88f},
                    new BatteryParameters { Temperature =89.02f, StateOfCharge = 64.91f},
                    new BatteryParameters { Temperature =74.76f, StateOfCharge = 11.27f},
                    new BatteryParameters { Temperature =66.31f, StateOfCharge = 16.3f},
                    new BatteryParameters { Temperature =33.01f, StateOfCharge = 56.89f},
                    new BatteryParameters { Temperature =25.2f, StateOfCharge = 52.0f},
                    new BatteryParameters { Temperature =28.3f, StateOfCharge = 33.5f},
                    new BatteryParameters { Temperature =46.5f, StateOfCharge = 26.56f}
                }
            }
        };

        [Fact(DisplayName = "Get Maximum of values returns exception")]
        public void GetMaximumValues_NullList_ReturnsException()
        {
            //Arrange
            var parameterStatistics = new ParameterStatistics();
            
            //Act and Assert
            Assert.Throws<Exception>(() => parameterStatistics.GetMaximumValues(null));
        }

        [Theory(DisplayName = "GetMaximumValues from parameters")]
        [MemberData(nameof(Parameters))]
        public void GetMaximumValues_ListOfBatteryParameters_ReturnsMaxBatteryParametersValues(List<BatteryParameters> parameterData)
        {
            //Arrange
            var parameterStatistics = new ParameterStatistics();

            //Act
            BatteryParameters maxParametersValues = parameterStatistics.GetMaximumValues(parameterData);

            //Assert
            Assert.True(maxParametersValues != null && maxParametersValues.StateOfCharge == 67.39f &&
                maxParametersValues.Temperature == 98.68f);
        }

        [Theory(DisplayName = "GetMinimumValues from parameters")]
        [MemberData(nameof(Parameters))]
        public void GetMinimumValues_ListOfBatteryParameters_ReturnsMaxBatteryParametersValues(List<BatteryParameters> parameterData)
        {
            //Arrange
            var parameterStatistics = new ParameterStatistics();

            //Act
            BatteryParameters minParametersValues = parameterStatistics.GetMinimumValues(parameterData);

            //Assert
            Assert.True(minParametersValues != null && minParametersValues.StateOfCharge == 6.37f &&
                minParametersValues.Temperature == 2.16f);
        }

        [Theory(DisplayName = "GetAverageOfParameters from given 5 parameters")]
        [MemberData(nameof(Parameters))]
        public void GetAverageOfParameters_ListOfBatteryParameters_ReturnsAvgBatteryParametersValues(List<BatteryParameters> parameterData)
        {
            //Arrange
            var parameterStatistics = new ParameterStatistics();

            //Act
            BatteryParameters avgParametersValues = parameterStatistics.GetAverageOfParameters(parameterData.GetRange(parameterData.Count - 5, 5));

            //Assert
            Assert.True(avgParametersValues != null && avgParametersValues.StateOfCharge == 37.05f &&
                avgParametersValues.Temperature == 39.864f);
        }
    }
}
