namespace AFSLogging
{
    /// <summary>
    /// Static class that represents logger
    /// </summary>
    public static class LoggerStatic
    {
        /// <summary>
        /// Count of wrote logs. 
        /// </summary>
        public static ulong LogCount { get; private set; }


        /// <summary>
        /// Indicates if logger increments the counter of logs
        /// </summary>
        public static bool CounterEnable { get; set; } = true;


        /// <summary>
        /// Clear text in log file
        /// </summary>
        /// <param name="path"></param>
        public static void ClearLogFile(string path)
        {
            if (File.Exists(path))
                File.WriteAllText(path, string.Empty);
        }


        /// <summary>
        /// Delete log file
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteLogFile(string path)
        {
            File.Delete(path);
        }


        /// <summary>
        /// Writes the INFO log by path and message
        /// </summary>
        /// <param name="path"></param>
        /// <param name="message"></param>
        public static void Log(string path, string message)
        {
            LogHelper.WriteLog(path, message);

            if (CounterEnable)
            {
                LogCount++;
            }
        }


        /// <summary>
        /// Writes the log by path, message and level
        /// </summary>
        /// <param name="path"></param>
        /// <param name="message"></param>
        /// <param name="level"></param>
        public static void Log(string path, string message, LogLevel level)
        {
            LogHelper.WriteLog(path, message, level);

            if (CounterEnable)
            {
                LogCount++;
            }
        }


        /// <summary>
        /// Resets the counter of log writes
        /// </summary>
        public static void ResetCounter()
        {
            LogCount = 0;
        }


        /// <summary>
        /// Normilize the log entries.
        /// <br/>
        /// RAM WARNING! When log file is too large it can be ram problems 
        /// </summary>
        public static void NormilizeLog(string path)
        {
            LogHelper.NormalizeLog(path);
        }
    }
}
