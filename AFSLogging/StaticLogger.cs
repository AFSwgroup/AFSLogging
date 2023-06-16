namespace AFSLogging
{
    /// <summary>
    /// Logger that have the static log file path passed by constructor
    /// </summary>
    public class StaticLogger : IStaticLogger
    {
        /// <summary>
        /// Count of wrote logs in this instance
        /// </summary>
        public ulong LogCount { get; private set; }

        /// <summary>
        /// Count of wrote logs in all instances
        /// </summary>
        public static ulong LogAllCount { get; private set; }

        /// <summary>
        /// Log file path. Can be only read. Sets only in constructor
        /// </summary>
        public readonly string LogFilePath;


        /// <summary>
        /// Indicates if logger increments the counter of logs
        /// </summary>
        public bool CounterEnable { get; set; } = true;

        private StaticLogger() { }

        public StaticLogger(string logFilePath)
        {
            LogFilePath = logFilePath;
        }


        /// <summary>
        /// Writes the simple info log
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            LogHelper.WriteLog(LogFilePath, message);
            if (CounterEnable)
            {
                LogCount++;
                LogAllCount++;
            }
        }


        /// <summary>
        /// Writes the log by <see cref="LogLevel"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        public void Log(string message, LogLevel level)
        {
            LogHelper.WriteLog(LogFilePath, message, level);
            if (CounterEnable)
            {
                LogCount++;
                LogAllCount++;
            }
        }


        /// <summary>
        /// Delete the log file
        /// </summary>
        public void DeleteLogFile()
        {
            File.Delete(LogFilePath);
        }


        /// <summary>
        /// Clears all data in log file. If file exists
        /// </summary>
        public void ClearLogFile()
        {
            if(File.Exists(LogFilePath))
                File.WriteAllText(LogFilePath, string.Empty);
        }


        /// <summary>
        /// Normilize the log entries.
        /// <br/>
        /// RAM WARNING! When log file is too large it can be ram problems 
        /// </summary>
        public void NormilizeLog()
        {
            LogHelper.NormalizeLog(LogFilePath);
        }
    }
}
