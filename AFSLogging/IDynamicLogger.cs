﻿namespace AFSLogging
{
    /// <summary>
    /// Base interface for dynamic logger
    /// </summary>
    public interface IDynamicLogger 
    {
        /// <summary>
        /// Log file path 
        /// </summary>
        public string LogFilePath { get; set; }


        /// <summary>
        /// Writes the simple info log
        /// </summary>
        /// <param name="message"></param>
        public void Log(string path, string message);


        /// <summary>
        /// Writes the log by <see cref="LogLevel"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        public void Log(string path, string message, LogLevel level);


        /// <summary>
        /// Delete the log file
        /// </summary>
        public void DeleteLogFile(string path);


        /// <summary>
        /// Clears all data in log file
        /// </summary>
        public void ClearLogFile(string path);


        /// <summary>
        /// Normiles the log entries
        /// </summary>
        /// <param name="path"></param>
        public void NormilizeLog();


        /// <summary>
        /// Normiles the log entries
        /// </summary>
        /// <param name="path"></param>
        public void NormilizeLog(string path);
    }
}
