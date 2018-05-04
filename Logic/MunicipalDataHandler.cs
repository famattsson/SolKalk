using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Globalization;
using Data;


namespace Logic
{
    static public class MunicipalDataHandler
    {

        static public List<ProducedMunicipalPower> GetTotalProducedPower(string kommun = null)
        {
            return MunicipalDataAccesser.GetTotalProducedPower(kommun);
        }
        static public List<ProducedMunicipalPower> GetProducedPowerOfDay(string date, string kommun = null)
        {
            return MunicipalDataAccesser.GetProducedPowerOfDay(ConvertDate(date), kommun);
        }
        static public List<ProducedMunicipalPower> GetProducedPowerOfMonth(string date, string kommun = null)
        {
            return MunicipalDataAccesser.GetProducedPowerOfMonth(ConvertDate(date),kommun);
        }
        static public List<ProducedMunicipalPower> GetProducedPowerOfYear(string date, string kommun = null)
        {
            return MunicipalDataAccesser.GetProducedPowerOfYear(ConvertDate(date), kommun);
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
    }
}
