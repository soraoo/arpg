using System;
using Framework.Factory;

namespace Framework.Common
{
    /// <summary>
    /// 被当前框架管理的基类，建议都继承于此
    /// 用Create Delete方法创建和销毁 而不是用new
    /// </summary>
    public class ZObject : IDisposable
    {
        private bool _disposed = false;

        public static T Create<T>() where T : ZObject
        {
            return ZObjectFactory.Create() as T;
        }

        public static void Delete(ZObject obj)
        {
            ZObjectFactory.Delete(obj);
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        /// <summary>
        /// 清理资源时候调用
        /// </summary>
        /// <param name="disposing">是否清理托管资源</param>
        protected virtual void OnDispose(bool disposing)
        {
            
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            OnDispose(disposing);
            _disposed = true;
        }

        ~ZObject()
        {
            Dispose(false);
        }
    }
}