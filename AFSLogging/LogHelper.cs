using System.Text;

namespace AFSLogging
{
    /// <summary>
    /// Helper log class. Only for this assembly
    /// </summary>
    internal class LogHelper
    {
        internal static void WriteLog(string path, string msg, LogLevel l = LogLevel.Info)
        {
            if(!File.Exists(path))
            {
                File.Create(path).Close();
            }

            string level = LevelToString(l);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('[');
            stringBuilder.Append(DateTime.Now);
            stringBuilder.Append('.');
            stringBuilder.Append(DateTime.Now.Millisecond);
            stringBuilder.Append(']');
            stringBuilder.Append(' ');
            stringBuilder.Append(level);
            stringBuilder.Append(' ');
            stringBuilder.Append(msg);
            stringBuilder.Append('\n');
            File.AppendAllText(path, stringBuilder.ToString());
        }


        internal static void NormalizeLog(string path)
        {
            if (path == null) return;

            string text;
            if(File.Exists(path))
            {
                text = File.ReadAllText(path);
            }
            else
            {
                return;
            }

            string[] normals = text.Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            File.WriteAllLines(path, normals);
        }


        private static string LevelToString(LogLevel level)
        {
            return Enum.GetName(typeof(LogLevel), level);
        }
    }
}
