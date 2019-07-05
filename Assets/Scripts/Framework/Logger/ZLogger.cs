namespace Framework.Logger
{
    public static class ZLogger
    {
        /// <summary>
        /// Log委托
        /// </summary>
        /// <param name="obj"></param>
        public delegate void LogHandler(object obj);

        /// <summary>
        /// 是否开启调试
        /// </summary>
        public static bool IsDebug = true;

        public static LogHandler Error = UnityEngine.Debug.LogError;
#if UNITY_EDITOR
        public static LogHandler Debug = UnityEngine.Debug.Log;
        public static LogHandler Warning = UnityEngine.Debug.LogWarning;
#else
        public static void Debug(object obj)
        {
            if (IsDebug)
                return;
            Debug.Log(obj);
        }

        public static void Warning(object obj)
        {
            if (IsDebug)
                return;
            Debug.LogWarning(obj);
        }
#endif
    }
}