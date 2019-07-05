using UnityEngine;
using System.Threading;
using Framework.Common;

namespace Framework.Async
{
    /// <summary>
    /// Async的管理器，一个mono单例
    /// </summary>
    public class AsyncManager : MonoSingleton<AsyncManager>
    {
        /// <summary>
        /// unity的上下文
        /// </summary>
        public static SynchronizationContext UnitySyncContext{ get; private set;}
        /// <summary>
        /// 当前上下文是否是unity
        /// </summary>
        public static bool IsUnityContext => Thread.CurrentThread.ManagedThreadId == unityThreadId;
        private static int unityThreadId;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            unityThreadId = Thread.CurrentThread.ManagedThreadId;
            UnitySyncContext = SynchronizationContext.Current;
        }
        
        
    }
}