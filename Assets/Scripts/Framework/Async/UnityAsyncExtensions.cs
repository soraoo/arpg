using System.Runtime.CompilerServices;
using UnityEngine;

namespace Framework.Async
{
    public static class UnityAsyncExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncOperationAwaiter GetAwaiter(this AsyncOperation @this) => new AsyncOperationAwaiter(@this);
    }
}