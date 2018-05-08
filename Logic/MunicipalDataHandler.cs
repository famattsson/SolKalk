using System;
using System.Collections.Generic;
using Data;

public struct HandledMunicipalData
{
    public List<ProducedMunicipalPower> powerRecords;
    public int weatherRating;
}

namespace Logic
{
    public class MunicipalDataHandler
    {

        static public HandledMunicipalData GetTotalProducedPower(string kommun = null, bool? perInhabitant = false)
        {
            if (perInhabitant == true)
            {
                HandledMunicipalData handledData = new HandledMunicipalData();
                handledData.powerRecords = ConvertToPerInhabitant(MunicipalDataAccesser.GetTotalProducedPower(kommun));
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
            else
            {
                HandledMunicipalData handledData = new HandledMunicipalData();
                handledData.powerRecords = MunicipalDataAccesser.GetTotalProducedPower(kommun);
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
            
        }

        static public HandledMunicipalData GetProducedPowerOfDay(string date, string kommun = null, bool? perInhabitant = false)
        {
            if (perInhabitant == true)
            {
                HandledMunicipalData handledData = new HandledMunicipalData();
                handledData.powerRecords = ConvertToPerInhabitant(MunicipalDataAccesser.GetProducedPowerOfDay(ConvertDate(date), kommun));
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
            else
            {
                HandledMunicipalData handledData = new HandledMunicipalData();
                handledData.powerRecords = MunicipalDataAccesser.GetProducedPowerOfDay(ConvertDate(date), kommun);
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
            
        }

        static public HandledMunicipalData GetProducedPowerOfMonth(string date, string kommun = null, bool? perInhabitant = false)
        {
            
            if(perInhabitant == true)
            {
                HandledMunicipalData handledData = new HandledMunicipalData();
                handledData.powerRecords = ConvertToPerInhabitant(MunicipalDataAccesser.GetProducedPowerOfMonth(ConvertDate(date),kommun));
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
            else
            {
                HandledMunicipalData handledData = new HandledMunicipalData();
                handledData.powerRecords = MunicipalDataAccesser.GetProducedPowerOfMonth(ConvertDate(date), kommun);
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
        }

        static public HandledMunicipalData GetProducedPowerOfYear(string date, string kommun = null, bool? perInhabitant = false)
        {
            if (perInhabitant == true)
            {
                HandledMunicipalData handledData = new HandledMunicipalData();
                handledData.powerRecords = ConvertToPerInhabitant(MunicipalDataAccesser.GetProducedPowerOfYear(ConvertDate(date), kommun));
                handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
                return handledData;
            }
            else
            {
                HandledMunicipalData handledData = new HandledMunicipalData();
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
            double firstFullSunValue = 80f;
            double irradianceRatingFactor = 100f / firstFullSunValue;
            // 100% / Första värdet som ger en full sol. Detta ger en faktor att multiplicera averageIrradiance med för att pass den till skalan

            foreach (var record in powerRecords)
            {
                averageIrradiance += record.Irradiance;
            }
            if(averageIrradiance > 0)
            {
                averageIrradiance /= powerRecords.Count;
            }
            return (int)Math.Round(averageIrradiance * irradianceRatingFactor);
        }

    }
}
