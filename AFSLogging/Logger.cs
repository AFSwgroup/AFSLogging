namespace AFSLogging
{
    /// <summary>
    /// Standart logger that operates with arguments in methods
    /// </summary>
    public class Logger : ILogger
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
        /// Indicates if logger increments the counter of logs
        /// </summary>
        public bool CounterEnable { get; set; } = true;


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

            if (CounterEnable)
            {
                LogCount++;
                LogAllCount++;
            }
        }


        public void Log(string path, string message, LogLevel level)
        {
            LogHelper.WriteLog(path, message, level);

            if (CounterEnable)
            {
                LogCount++;
                LogAllCount++;
            }
        }


        public void NormilizeLog(string path)
        {
            LogHelper.NormalizeLog(path);
        }
    }
}
