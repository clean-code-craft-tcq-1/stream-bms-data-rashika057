using System;
using System.Collections.Generic;

namespace Receiver
{
    class Receiver
    {
        static void Main(string[] args)
        {
            string readParameter;
            List<string> inputParameters = new List<string>();
            int i = 1;
            while ((readParameter = Console.ReadLine()) != null)
            {
                inputParameters.Add(readParameter); 
                i++;
                if (i == 15)
                {
                    var parameterParser = new ParameterParser(new JSONParameterParser());
                    List<BatteryParameters> batteryParameters = parameterParser.Parser(inputParameters);
                    ParameterStatistics parameterStatistics = new ParameterStatistics();
                    BatteryParameters parameters;
                    parameters = parameterStatistics.GetMaximumValues(batteryParameters);
                    Console.WriteLine("Maximum of soc " + parameters.StateOfCharge + " and maximum of temperature " + parameters.Temperature);
                    
                    parameters = parameterStatistics.GetMinimumValues(batteryParameters);
                    Console.WriteLine("Minimum of soc " + parameters.StateOfCharge + " and minimum of temperature " + parameters.Temperature);

                    if (batteryParameters.Count > 5)
                    {
                        parameters = parameterStatistics.GetAverageOfParameters(batteryParameters.GetRange(batteryParameters.Count - 5, 5));
                        Console.WriteLine("Average of soc " + parameters.StateOfCharge + " and Average of temperature " + parameters.Temperature);
                    }
                    i = 1;
                    inputParameters.Clear();
                }
            }
        }
    }
}
