using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using System.Threading.Tasks;

namespace Logic
{
    public static class CompanyDataHandler
    {
        static public List<ProducedCompanyPower> GetTotalProducedPower(string företag = null)
        {
            return CompanyDataAccesser.GetTotalProducedPower(företag);
        }
        static public List<ProducedCompanyPower> GetProducedPowerOfDay(string date, string företag = null)
        {

            return CompanyDataAccesser.GetProducedPowerOfDay(ConvertDate(date), företag);
        }
        static public List<ProducedCompanyPower> GetProducedPowerOfMonth(string date, string företag = null)
        {
            return CompanyDataAccesser.GetProducedPowerOfMonth(ConvertDate(date), företag);
        }
        static public List<ProducedCompanyPower> GetProducedPowerOfYear(string date, string företag = null)
        {
            return CompanyDataAccesser.GetProducedPowerOfYear(ConvertDate(date), företag);
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

