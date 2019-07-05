using System;

namespace Framework.Common
{
    public class CsSingleton<T> : ZObject where T : ZObject
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = Create<T>();
                return _instance;
            }
        }

        protected override void OnDispose(bool disposing)
        {
            base.OnDispose(disposing);
            if (!disposing) return;
            _instance.Dispose();
            _instance = null;
        }
    }
}