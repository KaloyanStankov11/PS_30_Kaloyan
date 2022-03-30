using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + "; "
                                  + LoginValidation.currentUserName + "; "
                                  + LoginValidation.currentUserRole + "; "
                                  + activity + Environment.NewLine;
            currentSessionActivities.Add(activityLine);
            if (File.Exists("Logger.txt"))
            {
                File.AppendAllText("Logger.txt", activityLine);
            }
        }

        public static IEnumerable<string> showLog()
        {
            List<string> allActivities = new List<string>();
            if (File.Exists("Logger.txt"))
            {
                StreamReader reader = new StreamReader("Logger.txt");
                string line = reader.ReadLine();
                while (line != null)
                {
                    allActivities.Add(line);
                    line = reader.ReadLine();
                }
                reader.Close();
            }
            return allActivities;
        }

        public static IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();
            return filteredActivities;
        }
    }
}
