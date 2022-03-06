using System.Diagnostics;

namespace ADFSTK.ExternalMFA.Common.Utils
{
    #region Log
    /// <summary>
    /// Log class
    /// </summary>
    public static class Log
    {
        private const string EventLogSource = "EduID";
        private const string EventLogGroup = "Application";

        /// <summary>
        /// Log constructor
        /// </summary>
        static Log()
        {
            if (!EventLog.SourceExists(Log.EventLogSource))
                EventLog.CreateEventSource(Log.EventLogSource, Log.EventLogGroup);
        }

        /// <summary>
        /// WriteEntry method implementation
        /// </summary>
        public static void WriteEntry(string message, EventLogEntryType type, int eventID)
        {
            EventLog.WriteEntry(EventLogSource, message, type, eventID);
        }
    }
    #endregion
}
