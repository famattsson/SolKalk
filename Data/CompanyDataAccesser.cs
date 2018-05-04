using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class CompanyDataAccesser
    {
        static public List<ProducedCompanyPower> GetTotalProducedPower(string företag = null)
        {
            using (var db = new SolkalkDbEntities())
            {
                if (företag != "" && företag != null)
                {
                    var query = from power in db.ProducedCompanyPowers
                                where power.Företag == företag
                                select power;
                    return query.ToList();
                }
                else
                {
                    var query = from power in db.ProducedCompanyPowers
                                select power;
                    return query.ToList();
                }
            }
        }
        static public List<ProducedCompanyPower> GetProducedPowerOfDay(Date date, string företag = null)
        {
            using (var db = new SolkalkDbEntities())
            {
                if (företag != "" && företag != null)
                {
                    var query = from power in db.ProducedCompanyPowers
                                where power.Företag == företag && power.Day == date.day
                                select power;
                    return query.ToList();
                }
                else
                {
                    var query = from power in db.ProducedCompanyPowers
                                where power.Day == date.day
                                select power;
                    return query.ToList();
                }
            }
        }
        static public List<ProducedCompanyPower> GetProducedPowerOfMonth(Date date, string företag = null)
        {
            using (var db = new SolkalkDbEntities())
            {
                if (företag != "" && företag != null)
                {
                    var query = from power in db.ProducedCompanyPowers
                                where power.Företag == företag && power.Month == date.month
                                select power;
                    return query.ToList();
                }
                else
                {
                    var query = from power in db.ProducedCompanyPowers
                                where power.Month == date.month
                                select power;
                    return query.ToList();
                }
            }
        }
        static public List<ProducedCompanyPower> GetProducedPowerOfYear(Date date, string företag = null)
        {
            using (var db = new SolkalkDbEntities())
            {
                if (företag != "" && företag != null)
                {
                    var query = from power in db.ProducedCompanyPowers
                                where power.Företag == företag && power.Year == date.year
                                select power;
                    return query.ToList();
                }
                else
                {
                    var query = from power in db.ProducedCompanyPowers
                                where power.Year == date.year
                                select power;
                    return query.ToList();
                }
            }
        }
    }
}