using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Framework.Async
{
    public class AsyncOperationAwaiter : INotifyCompletion
    {
        private AsyncOperation _asyncOperation;

        public AsyncOperationAwaiter(AsyncOperation asyncOperation)
        {
            _asyncOperation = asyncOperation;
        }
        
        public void GetResult(){}

        public bool IsComplete => _asyncOperation.isDone;

        public void OnCompleted(Action continuation)
        {
            _asyncOperation.completed += _ => continuation();
        }
    }
}