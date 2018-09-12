using System.Collections.Generic;

namespace DevOpsDashboard.Models
{
    public class DashboardMessageCache
    {
        private static List<DashboardMessageBase> m_cache = new List<DashboardMessageBase>();
        public static void Add(DashboardMessageBase msg)
        {
            m_cache.Add(msg);
            while (m_cache.Count>100)
            {
                m_cache.RemoveAt(0);
            }
        }

        public static DashboardMessageBase[] GetAll()
        {
            return m_cache.ToArray();
        }
    }
}
