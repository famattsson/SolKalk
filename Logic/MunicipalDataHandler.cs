using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Globalization;
using Data;

public struct HandledData
{
    public List<ProducedMunicipalPower> powerRecords;
    public int weatherRating;
}

namespace Logic
{
    public class MunicipalDataHandler
    {

        static public HandledData GetTotalProducedPower(string kommun = null, bool? perInhabitant = false)
        {
            if (perInhabitant == true)
            {
                HandledData handledData = new HandledData();
                handledData.powerRecords = ConvertToPerInhabitant(MunicipalDataAccesser.GetTotalProducedPower(kommun));
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
            else
            {
                HandledData handledData = new HandledData();
                handledData.powerRecords = MunicipalDataAccesser.GetTotalProducedPower(kommun);
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
            
        }

        static public HandledData GetProducedPowerOfDay(string date, string kommun = null, bool? perInhabitant = false)
        {
            if (perInhabitant == true)
            {
                HandledData handledData = new HandledData();
                handledData.powerRecords = ConvertToPerInhabitant(MunicipalDataAccesser.GetProducedPowerOfDay(ConvertDate(date), kommun));
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
            else
            {
                HandledData handledData = new HandledData();
                handledData.powerRecords = MunicipalDataAccesser.GetProducedPowerOfDay(ConvertDate(date), kommun);
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
            
        }

        static public HandledData GetProducedPowerOfMonth(string date, string kommun = null, bool? perInhabitant = false)
        {
            
            if(perInhabitant == true)
            {
                HandledData handledData = new HandledData();
                handledData.powerRecords = ConvertToPerInhabitant(MunicipalDataAccesser.GetProducedPowerOfMonth(ConvertDate(date),kommun));
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
            else
            {
                HandledData handledData = new HandledData();
                handledData.powerRecords = MunicipalDataAccesser.GetProducedPowerOfMonth(ConvertDate(date), kommun);
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
        }

        static public HandledData GetProducedPowerOfYear(string date, string kommun = null, bool? perInhabitant = false)
        {
            if (perInhabitant == true)
            {
                HandledData handledData = new HandledData();
                handledData.powerRecords = ConvertToPerInhabitant(MunicipalDataAccesser.GetProducedPowerOfYear(ConvertDate(date), kommun));
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
            else
            {
                HandledData handledData = new HandledData();
                handledData.powerRecords = MunicipalDataAccesser.GetProducedPowerOfYear(ConvertDate(date), kommun);
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
        }

        static private Date ConvertDate(string date)
        {
            Date formattedDate = new Date();
            var year = date.Split()[0];
            var month = date.Split()[1];
            var day = date.Split()[2];
            var hour = date.Split()[3];
            if (Int32.Parse(month) < 10)
            {
                month = "0" + month;
            }
            if (Int32.Parse(day) < 10)
            {
                day = "0" + day;
            }
            if (Int32.Parse(hour) < 10)
            {
                hour = "0" + hour;
            }
            formattedDate.year = year;
            formattedDate.month = month;
            formattedDate.day = day;
            formattedDate.hour = hour;
            formattedDate.date = String.Format("{0} {1} {2} {3}", year, month, day, hour);
            return formattedDate;
        }

        static private List<ProducedMunicipalPower> ConvertToPerInhabitant(List<ProducedMunicipalPower> powerRecords)
        {
            foreach(var record in powerRecords)
            {
                record.Energi /= record.Inhabitants;
            }
            return powerRecords;
        }

        static private int CalculateWeatherRating(List<ProducedMunicipalPower> powerRecords)
        {
            double averageIrradiance = 0;
            Dictionary<int, int> WeatherQualityIndex = new Dictionary<int, int> {
                {0,0}, {80,1},{160,2},{240,3},{320,4},{400,5}
            };
            foreach (var record in powerRecords)
            {
                averageIrradiance += record.Irradiance;
            }
            averageIrradiance /= powerRecords.Count;
            var lastValue = 0;
            foreach (var index in WeatherQualityIndex)
            {
                if (averageIrradiance >= WeatherQualityIndex[lastValue] && averageIrradiance < index.Key)
                {
                    return WeatherQualityIndex[lastValue];
                }
                lastValue = index.Key;
            }
            return WeatherQualityIndex[lastValue];
        }

    }
}
