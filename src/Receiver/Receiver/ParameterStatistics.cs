using System.Collections.Generic;

namespace Receiver
{
    public class ParameterStatistics
    {
        BatteryParameters batteryParameters = new BatteryParameters();
        public virtual BatteryParameters GetMaximumValues(List<BatteryParameters> parameters)
        {
            CheckParameterEmptyOrNull(parameters);
            float maximumSoc = float.MinValue;
            float maximumTemperature = float.MinValue;
            for (int i = 0; i < parameters.Count; i++)
            {
                maximumSoc = GetMaximumValue(parameters[i].StateOfCharge, maximumSoc);
                maximumTemperature = GetMaximumValue(parameters[i].Temperature, maximumTemperature);
            }

            batteryParameters.StateOfCharge = maximumSoc;
            batteryParameters.Temperature = maximumTemperature;
            return batteryParameters;
        }

        private void CheckParameterEmptyOrNull(List<BatteryParameters> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                throw new System.Exception("parameters cannot be null or empty");
        }

        private float GetMaximumValue(float value, float maximum)
        {
            if (value > maximum)
            {
                return value;
            }
            return maximum;
        }

        private float GetMinimumValue(float value, float minimum)
        {
            if (value < minimum)
            {
                return value;
            }
            return minimum;
        }

        public virtual BatteryParameters GetMinimumValues(List<BatteryParameters> parameters)
        {
            CheckParameterEmptyOrNull(parameters);
            float minimumSoc = float.MaxValue;
            float minimumTemperature = float.MaxValue;
            for (int i = 0; i < parameters.Count; i++)
            {
                minimumSoc = GetMinimumValue(parameters[i].StateOfCharge, minimumSoc);
                minimumTemperature = GetMinimumValue(parameters[i].Temperature, minimumTemperature);
            }

            batteryParameters.StateOfCharge = minimumSoc;
            batteryParameters.Temperature = minimumTemperature;
            return batteryParameters;
        }

        public virtual BatteryParameters GetAverageOfParameters(List<BatteryParameters> parameters)
        {
            CheckParameterEmptyOrNull(parameters);
            float sumStateOfCharge = 0;
            float sumTemperature = 0;
            for (int i = 0; i < parameters.Count; i++)
            {
                sumStateOfCharge += parameters[i].StateOfCharge;
                sumTemperature += parameters[i].Temperature;
            }

            batteryParameters.StateOfCharge = sumStateOfCharge / parameters.Count;
            batteryParameters.Temperature = sumTemperature / parameters.Count;
            return batteryParameters;
        }
    }
}
