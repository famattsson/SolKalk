using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using System.Threading.Tasks;

public struct HandledCompanyData
{
    public List<ProducedCompanyPower> powerRecords;
    public int weatherRating;
}

namespace Logic
{
    public static class CompanyDataHandler
    {

        static public HandledCompanyData GetTotalProducedPower(string företag = null, bool? perInhabitant = false)
        {
            HandledCompanyData handledData = new HandledCompanyData();
            handledData.powerRecords = CompanyDataAccesser.GetTotalProducedPower(företag);
            handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
            return handledData;
            
        }

        static public HandledCompanyData GetProducedPowerOfDay(string date, string företag = null, bool? perInhabitant = false)
        {
            HandledCompanyData handledData = new HandledCompanyData();
            handledData.powerRecords = CompanyDataAccesser.GetProducedPowerOfDay(ConvertDate(date), företag);
            handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
            return handledData;
        }

        static public HandledCompanyData GetProducedPowerOfMonth(string date, string företag = null, bool? perInhabitant = false)
        {
            HandledCompanyData handledData = new HandledCompanyData();
            handledData.powerRecords = CompanyDataAccesser.GetProducedPowerOfMonth(ConvertDate(date), företag);
            handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
            return handledData;
        }

        static public HandledCompanyData GetProducedPowerOfYear(string date, string företag = null, bool? perInhabitant = false)
        {

            HandledCompanyData handledData = new HandledCompanyData();
            handledData.powerRecords = CompanyDataAccesser.GetProducedPowerOfYear(ConvertDate(date), företag);
            handledData.weatherRating = CalculateWeatherRating(handledData.powerRecords);
            return handledData;
            
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


        static private int CalculateWeatherRating(List<ProducedCompanyPower> powerRecords)
        {
            double averageIrradiance = 0;
            double firstFullSunValue = 80f;
            double irradianceRatingFactor = 100f / firstFullSunValue;
            // 100% / Första värdet som ger en full sol. Detta ger en faktor att multiplicera averageIrradiance med för att pass den till skalan

            foreach (var record in powerRecords)
            {
                averageIrradiance += record.Irradiance;
            }
            if (averageIrradiance > 0)
            {
                averageIrradiance /= powerRecords.Count;
            }
            return (int)Math.Round(averageIrradiance * irradianceRatingFactor);
        }

    }
}

