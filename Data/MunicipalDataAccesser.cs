using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Data
{

    public struct Date
    {
        public string year;
        public string month;
        public string day;
        public string hour;
        public string date;
    }

    static public class MunicipalDataAccesser
    {

        //static public List<>

        static public List<ProducedMunicipalPower> GetTotalProducedPower(string kommun = null)
        {
            using (var db = new SolkalkDbEntities())
            {
                if (kommun != "" && kommun != null)
                {
                    var query = from power in db.ProducedMunicipalPowers
                                where power.Kommun == kommun
                                select power;
                    return query.ToList();
                }
                else
                {
                    var query = from power in db.ProducedMunicipalPowers
                                select power;
                    return query.ToList();
                }
            }
        }
        static public List<ProducedMunicipalPower> GetProducedPowerOfDay(Date date, string kommun = null)
        {
            using (var db = new SolkalkDbEntities())
            {
                if (kommun != "" && kommun != null)
                {
                    var query = from power in db.ProducedMunicipalPowers
                                where power.Kommun == kommun && power.Day == date.day
                                select power;
                    return query.ToList();
                }
                else
                {
                    var query = from power in db.ProducedMunicipalPowers
                                where power.Day == date.day
                                select power;
                    return query.ToList();
                }
            }
        }
        static public List<ProducedMunicipalPower> GetProducedPowerOfMonth(Date date, string kommun = null)
        {
            using (var db = new SolkalkDbEntities())
            {
                if (kommun != "" && kommun != null)
                {
                    var query = from power in db.ProducedMunicipalPowers
                                where power.Kommun == kommun && power.Month == date.month
                                select power;
                    return query.ToList();
                }
                else
                {
                    var query = from power in db.ProducedMunicipalPowers
                                where power.Month == date.month
                                select power;
                    return query.ToList();
                }
            }
        }
        static public List<ProducedMunicipalPower> GetProducedPowerOfYear(Date date, string kommun = null)
        {
            using (var db = new SolkalkDbEntities())
            {
                if (kommun != "" && kommun != null)
                {
                    var query = from power in db.ProducedMunicipalPowers
                                where power.Kommun == kommun && power.Year == date.year
                                select power;
                    return query.ToList();
                }
                else
                {
                    var query = from power in db.ProducedMunicipalPowers
                                where power.Year == date.year
                                select power;
                    return query.ToList();
                }
            }
        }
    }
}
