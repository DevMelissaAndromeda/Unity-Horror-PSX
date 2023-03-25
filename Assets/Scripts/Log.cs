using UnityEngine;



public enum LogType
{
    Normal,
    Warning,
    Error
}

public sealed class Log
{
    public static void LogMessage(string message, LogType logType)
    {
        switch (logType)
        {
            case LogType.Normal:
                Debug.Log(message);
                break;

            case LogType.Warning:
                Debug.LogWarning(message);
                break;

            case LogType.Error:
                Debug.LogError(message);
                break;
        }
    }
}
