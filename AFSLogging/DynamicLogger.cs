namespace AFSLogging
{
    /// <summary>
    /// Represents logger that can dynamically change path of log file
    /// <br></br>
    /// Has methods of <see cref="Logger"/> and <see cref="StaticLogger"/> in the same time
    /// </summary>
    public class DynamicLogger : IDynamicLogger
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
        /// Log file path 
        /// </summary>
        public string LogFilePath { get; set; }

        /// <summary>
        /// Indicates if logger increments the counter of logs
        /// </summary>
        public bool CounterEnable { get; set; } = true;


        private DynamicLogger() { }

        public DynamicLogger(string logFilePath)
        {
            LogFilePath = logFilePath;
        }



        public void ClearLogFile(string path)
        {
            if (File.Exists(path))
                File.WriteAllText(path, string.Empty);
        }


        public void DeleteLogFile(string path)
        {
            File.Delete(path);
        }


        public void Log(string path, string message)
        {
            LogHelper.WriteLog(path, message);

            if (!CounterEnable) return;

            unchecked
            {
                LogCount++;
                LogAllCount++;
            }
        }


        public void Log(string path, string message, LogLevel level)
        {
            LogHelper.WriteLog(path, message, level);

            if (!CounterEnable) return;

            unchecked
            {
                LogCount++;
                LogAllCount++;
            }
        }


        /// <summary>
        /// Writes the simple info log
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            LogHelper.WriteLog(LogFilePath, message);

            if (!CounterEnable) return;

            unchecked
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

            if (!CounterEnable) return;

            unchecked
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
            if (File.Exists(LogFilePath))
                File.WriteAllText(LogFilePath, string.Empty);
        }


        public void ResetInstanceCounter()
        {
            LogCount = 0;
        }


        public void ResetAllCounter()
        {
            LogAllCount = 0;
        }


        public void NormilizeLog()
        {
            LogHelper.NormalizeLog(LogFilePath);
        }


        public void NormilizeLog(string path)
        {
            LogHelper.NormalizeLog(path);
        }
    }
}
