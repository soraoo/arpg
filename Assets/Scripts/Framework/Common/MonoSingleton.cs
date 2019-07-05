using System;
using UnityEngine;

namespace Framework.Common
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                var name = typeof(T).Name;
                _instance = new GameObject(name, typeof(T)).GetComponent<T>();
                return _instance;
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void OnDestroy()
        {
            _instance = null;
        }
    }
}