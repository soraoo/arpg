using System.Collections.Generic;
using Framework.Common;
using Framework.Logger;

namespace Framework.Factory
{
    /// <summary>
    /// ZObject对象池
    /// </summary>
    public static class ZObjectPool
    {
        private class CycleObject
        {
            public ZObject Obj;
            public bool Use;
        }

        public static int Count { get; private set; }
        private const int InitCount = 5000;
        private static readonly List<CycleObject> Objects = new List<CycleObject>(InitCount);
        private static readonly object LockObj = new object();
        

        public static ZObject Create()
        {
            return GetFreeObject().Obj;
        }

        public static void Delete(ZObject obj)
        {
            var co = GetCycleObjectByObj(obj);
            if (co == null)
            {
                ZLogger.Warning($"{obj.GetType().Name} is not a cycle object");
                return;
            }

            co.Use = false;
        }

        private static CycleObject GetCycleObjectByObj(ZObject obj)
        {
            lock (LockObj)
            {
                var count = Objects.Count;
                for (var i = 0; i < count; i++)
                {
                    var co = Objects[i];
                    if (co.Obj.Equals(obj)) return co;
                }

                return null;
            }
        }

        private static CycleObject GetFreeObject()
        {
            lock (LockObj)
            {
                var count = Objects.Count;
                for (var i = 0; i < count; i++)
                {
                    var co = Objects[i];
                    if (!co.Use)
                        return co;
                }

                //create new
                if (Count >= InitCount)
                {
                    ZLogger.Warning("over init capacity, auto increasing count");
                }
                var cObject = new CycleObject
                {
                    Obj = new ZObject(), 
                    Use = true,
                };
                Objects.Add(cObject);
                Count++;
                return cObject;
            }
        }
    }
}