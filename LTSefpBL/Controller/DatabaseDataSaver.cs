using System.Collections.Generic;
using System.Linq;

namespace LTSefpBL.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (var dBase = new EconomicsContext()) 
            {
                var result = dBase.Set<T>().Where(t => true).ToList();
                return result;
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (var dBase = new EconomicsContext())
            {
                dBase.Set<T>().AddRange(item);
                dBase.SaveChanges();
            }
        }
    }
}
