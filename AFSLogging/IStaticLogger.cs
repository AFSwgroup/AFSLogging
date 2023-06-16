

namespace AFSLogging
{
    /// <summary>
    /// Base logger interface. Contract for implement logic
    /// </summary>
    public interface IStaticLogger
    {
        /// <summary>
        /// Writes the simple info log
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message);


        /// <summary>
        /// Writes the log by <see cref="LogLevel"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        public void Log(string message, LogLevel level);


        /// <summary>
        /// Delete the log file
        /// </summary>
        public void DeleteLogFile();


        /// <summary>
        /// Clears all data in log file
        /// </summary>
        public void ClearLogFile();


        /// <summary>
        /// Normiles the log entries
        /// </summary>
        /// <param name="path"></param>
        public void NormilizeLog();
    }
}
